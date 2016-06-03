using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PasswordReset : System.Web.UI.Page
{
    String aConnectingString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnResetPassword_Click(object sender, EventArgs e)
    {
        if (validation() && UpdateProMem())
        {
            lblNewPswdReset.Text = "Password changed Confirm";
            UpdateProMem();
            
        }
        else
        {
            lblResetPwsd.Text += "<br/> " + " Password change has not been confirm";  // \
        }
        if (validation() && UpdateMem())
        {
            lblNewPswdReset.Text = "Password changed Confirm";
            UpdateMem();
        }
        else
        {
            lblResetPwsd.Text += "<br/> " + " Password change has not been confirm";
        }
    }

    private bool UpdateProMem()
    {
        bool proMem = false;
        string reset = "Update Professionals set Passwords = '" + txtNewPswdReset.Text + "' where Usersname ='" + txtMemUsernameR.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);
        toReset.Open();
        int y;
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {
            y = getNew.ExecuteNonQuery();
            if (y > 0)
            {
                lblResetPwsd.Visible = true;

            }
            else
            {

                lblResetPwsd.Visible = false;

            }
            getNew.ExecuteNonQuery();
        }
        proMem = true;
        toReset.Close();
        return proMem;
    }

    private bool UpdateMem()
    {
        bool mems = false;
        string reset = "Update Members set Passwords = '" + txtNewPswdReset.Text + "',ConfirmPswd = '"
            + txtConfNewPswd.Text + "' where Usersname ='" + txtMemUsernameR.Text + "'";
        SqlConnection toReset = new SqlConnection(aConnectingString);
        toReset.Open();
        int y;
        using (SqlCommand getNew = new SqlCommand(reset, toReset))
        {
            y = getNew.ExecuteNonQuery();
                if (y > 0)
                {
                    lblResetPwsd.Visible = true;

                }
                else
                {

                    lblResetPwsd.Visible = false;

                }
            getNew.ExecuteNonQuery();
        }
        mems = true;
        toReset.Close();
        return mems;
    }


    private bool validation()
    {
        bool confirm = true;
        if (string.IsNullOrEmpty(txtMemUsernameR.Text) )      // ||
        {
            confirm = false;
            lblResetName.Text = "Usersname does not exist";
            
        }
        else
        {
            lblResetName.Text = "";
        }
        if (string.IsNullOrEmpty(txtNewPswdReset.Text))
        {
           
           confirm = false;
            lblNewPswdReset.Text = "Password entry is empty";
        }
        else
        {
            lblNewPswdReset.Text = "";
        }
        if (string.IsNullOrEmpty(txtConfNewPswd.Text))
        {
             confirm = false;
           lblResetPwsd.Text = "Password confirmation is required";

        }
        else
        {
            lblResetPwsd.Text = "Password Changed successfully";
                          
        }
        return confirm;
    }
}