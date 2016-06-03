using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ReadOtherSchedules : System.Web.UI.Page
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
            loadQuerySheet();
        }
        else
        {

            Response.Redirect("login.aspx");
        }
    }

    private void loadQuerySheet()
    {
        String pick = "Select Id, DOB,Location,City,MedicalCard,Reasons from OtherConcerns " +
       " where Id = '" + ddlQueryPickUp.SelectedValue + "'";

        using (SqlConnection acon = new SqlConnection(aConnectingString))
        {
            SqlDataReader myReader = null;
            SqlCommand myInfo = new SqlCommand(pick, acon);
            acon.Open();
            myReader = myInfo.ExecuteReader();

            // DropDownVisitationList();
            while (myReader.Read())
            {

                lblidOthers.Text = (myReader["Id"].ToString());
               // lblOtherNameResult.Text = (myReader["Lastname"].ToString() + " " + myReader["FirstName"].ToString());
                
                lblOtherdobResult.Text = (myReader["DOB"].ToString());
                txtOtherSchdlLoc.Text = (myReader["Location"].ToString());
                txtOtherScdlCity.Text = (myReader["City"].ToString());
                //  lblAChoicePhone.Text = (myReader["PhoneNum"].ToString());
                lblOtherChoiceMedCd.Text = (myReader["MedicalCard"].ToString());
                txtOChoiceWhy.Text = (myReader["Reasons"].ToString());
                //updateVisitation();

            } DropDownOtherQueryList();

            acon.Close();
        }
    }

    private void DropDownOtherQueryList()
    {
        string loadLoc = aConnectingString;
        using (SqlConnection Upcon = new SqlConnection(loadLoc))
        {
            SqlCommand cmd = new SqlCommand("Select distinct Id from OtherConcerns", Upcon);

            Upcon.Open();
            ddlQueryPickUp.DataSource = cmd.ExecuteReader();
            ddlQueryPickUp.DataTextField = "Id";
            ddlQueryPickUp.DataValueField = "Id";
            ddlQueryPickUp.DataBind();
            ddlQueryPickUp.Items.Insert(0, new ListItem("Select ID", "0"));
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

    private void AcceptOtherConcerns()
    {
        string reset = "Update OtherConcerns set AcceptCol= '" + txtAcceptinOtherFella.Text + "' where Id= '" + lblidOthers.Text + "' and Reasons = '" + txtOChoiceWhy.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);

        toReset.Open();
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {
            getNew.ExecuteNonQuery();
        }
        toReset.Close();
    }

    private void CancelOtherConcerns()
    {
        string reset = "Update OtherConcerns set CancelCol= '" + txtCancelinOtherfella.Text + "', AcceptCol= '" + "" + "' where Id= '" + lblidOthers.Text + "' and Reasons = '" + txtOChoiceWhy.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);

        toReset.Open();

        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {
            getNew.ExecuteNonQuery();
        }
        toReset.Close();

    }

    protected void btnFinishOthersReading_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReplyBoard.aspx");
    }

    protected void btnAcceptOther_Click(object sender, EventArgs e)
    {
        AcceptOtherConcerns();
        lblidOthers.Text = "";
        lblOtherdobResult.Text = "";
        txtOtherSchdlLoc.Text = "";
        txtOtherScdlCity.Text = "";
        lblOtherChoiceMedCd.Text = "";
        txtOChoiceWhy.Text = "";
        txtAcceptinOtherFella.Text = "";
    }

    protected void btnCancelOther_Click(object sender, EventArgs e)
    {
        CancelOtherConcerns();
        lblidOthers.Text = "";
        lblOtherdobResult.Text = "";
        txtOtherSchdlLoc.Text = "";
        txtOtherScdlCity.Text = "";
        lblOtherChoiceMedCd.Text = "";
        txtOChoiceWhy.Text = "";
        txtCancelinOtherfella.Text = "";
    }
}