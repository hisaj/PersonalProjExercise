using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class BookVisitation : System.Web.UI.Page
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

    protected void btnGetVisitID_Click(object sender, EventArgs e)
    {
        string vid = "select ID from Members where usersname = '" + lblCurrentUser.Text + "'";
        using (SqlConnection myvId = new SqlConnection(aConnectingString))
        {
            SqlCommand fetchVId = new SqlCommand(vid, myvId);
            myvId.Open();
            //fetchId.ExecuteNonQuery();
            lblShowVisitMemID.Text = fetchVId.ExecuteScalar().ToString(); // display the value of the ID row with corresponding Label
            getData();
            myvId.Close();
        }
       
    }

    private void getData()
    {
        string loadData = "select Surname,Firstname, Location, City from Members where usersname = '" + lblCurrentUser.Text + "'";
        using (SqlConnection acon = new SqlConnection(aConnectingString))
        {
            SqlDataReader aReader = null;
            SqlCommand myInfo = new SqlCommand(loadData, acon);
            acon.Open();
            aReader = myInfo.ExecuteReader();

            while (aReader.Read())
            {
                txtVisitSurName.Text = (aReader["Surname"].ToString());
                txtVisitFirName.Text = (aReader["FirstName"].ToString());
                txtVisitLoc.Text = (aReader["Location"].ToString());
                txtVisitCity.Text = (aReader["City"].ToString());
            }
            acon.Close();
        }

    }

    private void saveVisitationHistory()
    {
        string medC;
        string schedule = "Insert into Visitations" + "(Id, Lastname, Firstname, DOB, Location, City, ChoiceTime, Reasons, PhoneNum, ChosenDay, MedicalCard, Period)"
         + "values(@Id, @LastN,@Fname,@dob,@loc,@cit, @time, @why,@phonNum, @day, @mdc, getdate())";

        using (SqlConnection getCon = new SqlConnection(aConnectingString))
        {
            SqlCommand input = new SqlCommand(schedule, getCon);

            getCon.Open();
            if (CheckBoxMedVisitYes.Checked && !CheckBoxMedVisitNo.Checked)
            {
                medC = "1";
            }
            else
            {
                medC = "0";

            }

            input.Parameters.AddWithValue("@Id", lblShowVisitMemID.Text);
            input.Parameters.AddWithValue("@LastN", txtVisitSurName.Text);
            input.Parameters.AddWithValue("@Fname", txtVisitFirName.Text);
            input.Parameters.AddWithValue("@dob", txtVisitDOB.Text);
            input.Parameters.AddWithValue("@loc", txtVisitLoc.Text);
            input.Parameters.AddWithValue("@cit", txtVisitCity.Text);
            input.Parameters.AddWithValue("@time", ddlVisitTime.SelectedItem.Text);
            input.Parameters.AddWithValue("@why", txtVisitReason.Text);
            input.Parameters.AddWithValue("@phonNum", txtVisitPhone.Text);
            input.Parameters.AddWithValue("@day", ddlVisitDay.SelectedItem.Text);
            input.Parameters.AddWithValue("@mdc", medC);
            input.ExecuteNonQuery();
            getCon.Close();
        }
        reset();
    }

    private bool validateForm()
    {
        bool check = true;
        if (!(CheckBoxMedVisitYes.Checked || CheckBoxMedVisitNo.Checked))
        {
            check = false;
            lblVistErr.Text = "One or more CheckBox required is empty";
        }
        else
       if ((string.IsNullOrEmpty(txtVisitSurName.Text)) || (string.IsNullOrEmpty(txtVisitFirName.Text)) || (string.IsNullOrEmpty(txtVisitDOB.Text))
                || (string.IsNullOrEmpty(txtVisitReason.Text)) || (string.IsNullOrEmpty(txtVisitLoc.Text)) 
                || (string.IsNullOrEmpty(txtVisitCity.Text)) || (string.IsNullOrEmpty(txtVisitPhone.Text)))
        {
             check = false;
             lblVistErr.Text = "One or more data required is empty";
         }
       else
          if ((ddlVisitTime.SelectedIndex == 0) || (ddlVisitDay.SelectedIndex == 0))
         {
              check = false;
               lblVistErr.Text = "Your Time or Day is not selected";
          }
        else

                    lblVistErr.Text = "";


        return check;
    }

    private void reset()
    {
        lblShowVisitMemID.Text = "";
        txtVisitSurName.Text = "";
        txtVisitFirName.Text = "";
        txtVisitDOB.Text = "";
        txtVisitReason.Text = "";
        ddlVisitTime.SelectedIndex = 0;
        txtVisitLoc.Text = "";
        txtVisitCity.Text = "";
        ddlVisitDay.SelectedIndex = 0;
        CheckBoxMedVisitYes.Checked = false;
        CheckBoxMedVisitNo.Checked = false;
        lblVistErr.Text = "";
    }

    protected void btnSubmitVisit_Click(object sender, EventArgs e)
    {
        if (validateForm())
        {
            saveVisitationHistory();
            Response.Redirect("ScheduleAppointment.aspx");
        }
    }
    protected void btnCancelVisit_Click(object sender, EventArgs e)
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