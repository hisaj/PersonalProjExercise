using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class QueryConcerns : System.Web.UI.Page
{
    String aConnectingString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";
    
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["Log"] != null)
        {
            lblCurrentUser.Text = Request.Cookies["Log"]["Usersname"].ToString();
        }
        else
        {

            Response.Redirect("login.aspx");
        }

    }

    

    protected void btnOthersGetID_Click(object sender, EventArgs e)
    {
       
        string oid = "select ID from Members where usersname = '" + lblCurrentUser.Text + "'";
        using (SqlConnection myoId = new SqlConnection(aConnectingString))
        {
            SqlCommand fetchOId = new SqlCommand(oid, myoId);
            myoId.Open();
            //fetchId.ExecuteNonQuery();
            lblshowOthersID.Text = fetchOId.ExecuteScalar().ToString(); // display the value of the ID row with corresponding Label
            getData();
            myoId.Close();
        }
        
    }

    private void getData()
    {
        string loadData = "select Surname,Firstname, Location, City from Members where usersname = '" + lblCurrentUser.Text + "'";
        using (SqlConnection acon = new SqlConnection(aConnectingString))
        {
            SqlDataReader myReader = null;
            SqlCommand myInfo = new SqlCommand(loadData, acon);
            acon.Open();
            myReader = myInfo.ExecuteReader();

            while (myReader.Read())
            {
                txtOtherSchdlLoc.Text = (myReader["Location"].ToString());
                txtOtherScdlCity.Text = (myReader["City"].ToString());
            }
            acon.Close();
        }

    }

    private void saveOtherQueryHistory()
    {
        string medC;
        string schedule = "Insert into OtherConcerns" + "(Id, DOB, Reasons,Location, City, MedicalCard, Period)"
         + "values(@Id, @dob, @why, @loc, @cit, @mdc, getdate())";
        using (SqlConnection getCon = new SqlConnection(aConnectingString))
        {
            SqlCommand input = new SqlCommand(schedule, getCon);

            getCon.Open();
            if (CheckBoxOtherYes.Checked && !CheckBoxOtherNo.Checked)
            {
                medC = "1";
            }
            else
            {
                medC = "0";

            }

            input.Parameters.AddWithValue("@Id", lblshowOthersID.Text);
            input.Parameters.AddWithValue("@dob", txtOtherDOB.Text);
            input.Parameters.AddWithValue("@why", txtOthersPurpose.Text);
            input.Parameters.AddWithValue("@loc", txtOtherSchdlLoc.Text);
            input.Parameters.AddWithValue("@cit", txtOtherScdlCity.Text);       
            input.Parameters.AddWithValue("@mdc", medC);
            input.ExecuteNonQuery();
            getCon.Close();
        }
        reset();
    }

    private bool validateForm()
    {
        bool check = true;
        if (!(CheckBoxOtherYes.Checked || CheckBoxOtherNo.Checked))
        {
            check = false;
            lblQueryFErr.Text = "One or more CheckBox required is empty";
        }
        else

            if ((string.IsNullOrEmpty(txtOtherDOB.Text)) || (string.IsNullOrEmpty(txtOthersPurpose.Text)) || (string.IsNullOrEmpty(txtOtherSchdlLoc.Text))
                || (string.IsNullOrEmpty(txtOtherScdlCity.Text)))
            {
                check = false;
                lblQueryFErr.Text = "One or more data required is empty";
            }
            else
              lblQueryFErr.Text = "";

        return check;
    }

    private void reset()
    {
        lblshowOthersID.Text = "";
        txtOtherDOB.Text = "";
        txtOthersPurpose.Text = "";
        txtOtherSchdlLoc.Text = "";
        txtOtherScdlCity.Text = "";
        CheckBoxOtherYes.Checked = false;
        CheckBoxOtherNo.Checked = false;
    }

    protected void btnQuerySubmit_Click(object sender, EventArgs e)
    {
        if (validateForm())
        {
            saveOtherQueryHistory();
            Response.Redirect("ScheduleAppointment.aspx");
        }
    }
    protected void btnCancelQuery_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void btnCheckReplies_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReplyBoard.aspx");
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        HttpCookie mylogin = new HttpCookie("Log");
        mylogin.Expires = DateTime.Now.AddHours(-1);
        Response.Cookies.Add(mylogin);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();
        Response.Redirect("login.aspx");
    }
    
}