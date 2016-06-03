using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ReadAppointment : System.Web.UI.Page
{
    String aConnectingString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Prof"] != null && Request.Cookies["Log"] != null)
        {
            string title = Request.Cookies["Prof"]["Profession"].ToString();
            string user = Request.Cookies["Log"]["Usersname"].ToString();
            lblCurrentUser.Text = title + "  " + user;
           // lblCurrentUser.Text = Request.Cookies["Log"]["Usersname"].ToString();
            loadSheetPage();
        }
        else
        {

            Response.Redirect("login.aspx");
        }
    }


    private void loadSheetPage()
    {

        String pick = "Select Id, Hospital, GP, Lastname, Firstname,ChosenDay,DOB,Location,City,ChoiceTime,MedicalCard,Reasons, AppAccept,AppCancel from TraceSchedules  where Id = '" + ddlAppointmentPickUp.SelectedValue + "'";

        using (SqlConnection acon = new SqlConnection(aConnectingString))
        {
            SqlDataReader myReader = null;
            SqlCommand myInfo = new SqlCommand(pick, acon);
            acon.Open();         
            myReader = myInfo.ExecuteReader();

            // DropDownVisitationList();
            while (myReader.Read())
            {

                lblRAIDResult.Text = (myReader["Id"].ToString());
                lblAppHosResult.Text = (myReader["Hospital"].ToString());
                lblAppGPResult.Text = (myReader["GP"].ToString());
                lblANameResult.Text = (myReader["Lastname"].ToString() + " " + myReader["FirstName"].ToString());
                lblAChoiceDay.Text = (myReader["ChosenDay"].ToString());
                lblAChoiceDOB.Text = (myReader["DOB"].ToString());
                lblAChoiceLoc.Text = (myReader["Location"].ToString());
                lblAChoiceCity.Text = (myReader["City"].ToString());
              //  lblAChoicePhone.Text = (myReader["PhoneNum"].ToString());
                lblAChoicePhone.Text = (myReader["MedicalCard"].ToString());
                txtAChoiceWhy.Text = (myReader["Reasons"].ToString());
                txtAcceptinFella.Text = (myReader["AppAccept"].ToString());
                txtCancelinfella.Text = (myReader["AppCancel"].ToString());
                //updateVisitation();

            }
            DropDownAppointmentList();
            acon.Close();
        }
    }

    private void DropDownAppointmentList()
    {
        string loadLoc = aConnectingString;
        using (SqlConnection Upcon = new SqlConnection(loadLoc))
        {
            SqlCommand cmd = new SqlCommand("Select distinct ID from TraceSchedules ", Upcon);

            Upcon.Open();
            ddlAppointmentPickUp.DataSource = cmd.ExecuteReader();
            ddlAppointmentPickUp.DataTextField = "Id";
            ddlAppointmentPickUp.DataValueField = "Id";
            ddlAppointmentPickUp.DataBind();
            ddlAppointmentPickUp.Items.Insert(0, new ListItem("Select ID", "0"));
        }
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

    protected void btnViewAppointSheet_Click(object sender, EventArgs e)
    {
        loadSheetPage();
    }

    private void AcceptAppointment()
    {
        string reset = "Update TraceSchedules set AppAccept= '" + txtAcceptinFella.Text + "', AppCancel= '" + "NULL" + "' where Id= '" + lblRAIDResult.Text + "' and Reasons = '" + txtAChoiceWhy.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);

        toReset.Open();
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {
            getNew.ExecuteNonQuery();
        }
        toReset.Close();
    }

    private void CancelAppointment()
    {
        string reset = "Update TraceSchedules set AppCancel= '" + txtCancelinfella.Text + "', AppAccept= '" + "NULL" + "' where Id= '" + lblRAIDResult.Text + "' and Reasons = '" + txtAChoiceWhy.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);

        toReset.Open();
       
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {
                   getNew.ExecuteNonQuery();
        }
        toReset.Close();
       
    }

    protected void btnAcceptApptmt_Click(object sender, EventArgs e)
    {
               AcceptAppointment();
               lblRAIDResult.Text = "";
               lblAppHosResult.Text = "";
               lblAppGPResult.Text = "";
               lblANameResult.Text = "";
               lblAChoiceDay.Text = "";
               lblAChoiceDOB.Text = "";
               lblAChoiceLoc.Text = "";
               lblAChoiceCity.Text = "";
               lblAChoicePhone.Text = "";
               txtAChoiceWhy.Text = "";
               txtAcceptinFella.Text = "";
               txtCancelinfella.Text = "";
    }

    protected void btnCancelApptmt_Click(object sender, EventArgs e)
    {
        CancelAppointment();
        lblRAIDResult.Text = "";
        lblAppHosResult.Text = "";
        lblAppGPResult.Text = "";
        lblANameResult.Text = "";
        lblAChoiceDay.Text = "";
        lblAChoiceDOB.Text = "";
        lblAChoiceLoc.Text = "";
        lblAChoiceCity.Text = "";
        lblAChoicePhone.Text = "";
        txtAChoiceWhy.Text = "";
        txtCancelinfella.Text = "";
        txtAcceptinFella.Text = "";
    }

    protected void btnFinishAppReading_Click(object sender, EventArgs e)
    {
        //txtCancelinfella.Text = "";
        //txtAcceptinFella.Text = "";
        Response.Redirect("ReplyBoard.aspx");
    }
}