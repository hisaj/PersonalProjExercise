using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ReadVisitationSchedules : System.Web.UI.Page
{
    String aConnectingString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Prof"] != null && Request.Cookies["Log"] != null)
        {
            string title = Request.Cookies["Prof"]["Profession"].ToString();
            string user = Request.Cookies["Log"]["Usersname"].ToString();
            lblCurrentUser.Text = title + "  " + user;
          //  lblCurrentUser.Text = Request.Cookies["Log"]["Usersname"].ToString();
            loadVisitationSheet();
        }
        else
        {

            Response.Redirect("login.aspx");
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

    private void loadVisitationSheet()
    {
        
        String pick = "Select Id, Lastname, Firstname,ChosenDay,DOB,Location,City,ChoiceTime,PhoneNum,MedicalCard,Reasons from Visitations" +
        " where Id = '"+ ddlVisitationPickUp.SelectedValue + "'" ;
          
        using (SqlConnection acon = new SqlConnection(aConnectingString))
        {
            SqlDataReader myReader = null;
            SqlCommand myInfo = new SqlCommand(pick,acon);
            //myInfo.CommandType = CommandType.StoredProcedure;
           // myInfo.CommandText = "VisitsView";
            acon.Open();
            //myInfo.Connection = acon;            
             myReader = myInfo.ExecuteReader();

            // DropDownVisitationList();
            while (myReader.Read())
            {
               
                lblVSIDResult.Text = (myReader["Id"].ToString());
                lblVNameResult.Text = (myReader["Lastname"].ToString() + " " + myReader["FirstName"].ToString());
                lblVChoiceDay.Text = (myReader["ChosenDay"].ToString());
                lblVChoiceDOB.Text = (myReader["DOB"].ToString());
                lblVChoiceLoc.Text = (myReader["Location"].ToString());
                lblVChoiceCity.Text = (myReader["City"].ToString());
                lblVDispTime.Text = (myReader["ChoiceTime"].ToString());
                lblVChoicePhone.Text = (myReader["PhoneNum"].ToString());
                lblVChoiceMedCd.Text = (myReader["MedicalCard"].ToString());
                txtVChoiceWhy.Text = (myReader["Reasons"].ToString());
                //updateVisitation();

            } DropDownVisitationList();
            
            acon.Close();
        }

    }
    private void DropDownVisitationList()
    {
        string loadLoc = aConnectingString;
        using (SqlConnection Upcon = new SqlConnection(loadLoc))
        {
            SqlCommand cmd = new SqlCommand("Select distinct Id from Visitations", Upcon);

            Upcon.Open();
            ddlVisitationPickUp.DataSource = cmd.ExecuteReader();
            ddlVisitationPickUp.DataTextField = "Id";
            ddlVisitationPickUp.DataValueField = "Id";
            ddlVisitationPickUp.DataBind();
            ddlVisitationPickUp.Items.Insert(0, new ListItem("Select ID", "0"));
        }
    }

   /* private bool updateVisitation()
    {
        bool UpdateApp = false;
        string reset = "Update Visitations set DOB= '" + lblVChoiceDOB.Text + "', Reasons= '" + txtVChoiceWhy.Text + "', ChoiceTime= '" + lblVDispTime + "'"
           + " , Location= '" + lblVChoiceLoc.Text + "', City= '" + lblVChoiceLoc.Text + "', ChosenDay= '" + lblVChoiceDay + "' where Id= '" + lblVSIDResult.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);

        toReset.Open();
        // int y;
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {

            //y = (int)getNew.ExecuteScalar();
            //if (y > 0)
            //{
            getNew.ExecuteNonQuery();
            // }

        }
        UpdateApp = true;
        toReset.Close();
        return UpdateApp;
    }*/
    private void populateform()
    {
        string loadcit = aConnectingString;
        DataSet loc = new DataSet();
        SqlDataAdapter myda = new SqlDataAdapter("Select *  FROM Visitations where Id = '" + ddlVisitationPickUp.SelectedValue + "'", loadcit);
        myda.Fill(loc);

        ddlVisitationPickUp.DataSource = loc;
        ddlVisitationPickUp.DataValueField = "Id";
        ddlVisitationPickUp.DataBind();
    }/**/

    protected void btnViewVisitSheet_Click(object sender, EventArgs e)
    {
        
            loadVisitationSheet();
        
        //    lblVSIDResult.Text = "";
        //lblVNameResult.Text = "";
        //lblVChoiceDay.Text = "";
        //lblVChoiceDOB.Text = "";
        //lblVChoiceLoc.Text = "";
        //lblVChoiceCity.Text = "";
        //lblVDispTime.Text = "";
        //lblVChoicePhone.Text = "";
        //lblVChoiceMedCd.Text = "";
        //txtVChoiceWhy.Text = "";
    }

    private void AcceptVisitation()
    {
       // bool yesVisit = false;
        string reset = "Update Visitations set AcceptCol= '" + txtAcceptinVistFella.Text + "' where Id= '" + lblVSIDResult.Text + "' and Reasons = '" + txtVChoiceWhy.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);

        toReset.Open();
        // int y;
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {

            //y = (int)getNew.ExecuteScalar();
            //if (y > 0)
            //{
            getNew.ExecuteNonQuery();
            // }

        }
        //yesVisit = true;
        toReset.Close();
       // return yesVisit;
    }

    private void CancelVisitation()
    {
        // bool yesVisit = false;
        string reset = "Update Visitations set CancelCol= '" + txtCancelinVistfella.Text + "', AcceptCol= '" + "" + "' where Id= '" + lblVSIDResult.Text + "' and Reasons = '" + txtVChoiceWhy.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);

        toReset.Open();
        // int y;
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {

            //y = (int)getNew.ExecuteScalar();
            //if (y > 0)
            //{
            getNew.ExecuteNonQuery();
            // }

        }
        //yesVisit = true;
        toReset.Close();
        // return yesVisit;
    }

    protected void btnAcceptVist_Click(object sender, EventArgs e)
    {
        AcceptVisitation();
        lblVSIDResult.Text = "";
        lblVNameResult.Text = "";
        lblVChoiceDay.Text = "";
        lblVChoiceDOB.Text = "";
        lblVChoiceLoc.Text = "";
        lblVChoiceCity.Text = "";
        lblVDispTime.Text = "";
        lblVChoicePhone.Text = "";
        lblVChoiceMedCd.Text = "";
        txtVChoiceWhy.Text = "";
        txtAcceptinVistFella.Text = "";
    }

    protected void btnCancelVist_Click(object sender, EventArgs e)
    {
        CancelVisitation();
        lblVSIDResult.Text = "";
        lblVNameResult.Text = "";
        lblVChoiceDay.Text = "";
        lblVChoiceDOB.Text = "";
        lblVChoiceLoc.Text = "";
        lblVChoiceCity.Text = "";
        lblVDispTime.Text = "";
        lblVChoicePhone.Text = "";
        lblVChoiceMedCd.Text = "";
        txtVChoiceWhy.Text = "";
        txtCancelinVistfella.Text = "";
    }

    protected void btnFinishVisitReading_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReplyBoard.aspx");
    }
}