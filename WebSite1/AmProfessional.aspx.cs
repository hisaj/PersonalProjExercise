using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AmProfessional : System.Web.UI.Page
{
    String aConnectingString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnProRegister_Click(object sender, EventArgs e)
    {
        string reset = "Update Professionals set Profession = '" + txtProfession.Text + "',WorkAddress = '"
            + txtWorkAddress.Text + "',WorkDuration = '" + txtDuration.Text + "' where Email ='" + txtConfirmProEmail.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);
        toReset.Open();
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {
            getNew.ExecuteNonQuery();
        }
        toReset.Close(); 
        Response.Redirect("RegistrationSuccess.aspx");

    }

    //method to fetch and display professional members ID in order to know it 
    private void getMyID()
    {
        string id = "select ID from Professionals where Email = '" + txtConfirmProEmail.Text + "'";
        using (SqlConnection myId = new SqlConnection(aConnectingString))
        {
            SqlCommand fetchId = new SqlCommand(id, myId);
            myId.Open();
            //fetchId.ExecuteNonQuery();
            lblShowProfID.Text = fetchId.ExecuteScalar().ToString(); // display the value of the ID row with corresponding Label
        }
    }

    protected void btnOkProID_Click(object sender, EventArgs e)
    {
        getMyID();
    }
}