using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    String aConnectingString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";
    int result = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    private bool ProOption()
    {
        bool checkpro = false;
        string getLog = "Select * from Professionals where Usersname = '" + txtMemLogin.Text + "' and Passwords = '" + txtMemLoginPswd.Text + "'";
        SqlConnection entry = new SqlConnection(aConnectingString);
        SqlDataAdapter mine = new SqlDataAdapter(getLog, entry);
        DataTable mem = new DataTable();
        mine.Fill(mem);

        if (ValidateLogin() && mem.Rows.Count.ToString() == "1")
        {
            HttpCookie mylogin = new HttpCookie("Log");
            HttpCookie myTitle = new HttpCookie("Prof");
            mylogin["Usersname"] = mem.Rows[0]["Usersname"].ToString();
            myTitle["Profession"] = mem.Rows[0]["Profession"].ToString();
            mylogin.Expires = DateTime.Now.AddHours(1);
            myTitle.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(mylogin);
            Response.Cookies.Add(myTitle);
            checkpro = true;
            //Response.Redirect("ReplyBoard.aspx");
        }
        return checkpro;
    }

    private bool MemOption()
    {
        bool checkmem = false;
        string getLog = "Select * from Members where Usersname = '" + txtMemLogin.Text + "' and Passwords = '" + txtMemLoginPswd.Text + "'";
        SqlConnection entry = new SqlConnection(aConnectingString);
        SqlDataAdapter mine = new SqlDataAdapter(getLog, entry);
        DataTable mem = new DataTable();
        mine.Fill(mem);

        if (ValidateLogin() && mem.Rows.Count.ToString() == "1")
        {
            HttpCookie mylogin = new HttpCookie("Log");
            mylogin["Usersname"] = mem.Rows[0]["Usersname"].ToString();
            mylogin.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Add(mylogin);
            checkmem = true;
           // Response.Redirect("ScheduleAppointment.aspx");
        }
        return checkmem;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (ProOption())
        {
            Response.Redirect("ReplyBoard.aspx");
        }
        else if (MemOption())
        {
            Response.Redirect("ScheduleAppointment.aspx");
        }
        //else
        //    Response.Write("<script language=javascript> alert('Invalid User. Cannot find Data')</script>");
     }

    private bool ValidateLogin()
    {
        string aNameP = "Select Usersname from Professionals";
        string aPP = "Select Passwords from Professionals ";
        string aMem = "Select Usersname from Members ";
        string aMM = "Select Passwords from Members ";
        bool am_In = true;
        using (SqlConnection aCon = new SqlConnection(aConnectingString))
        {
            try
            {
                SqlCommand myUP = new SqlCommand(aNameP, aCon);
                SqlCommand myPw = new SqlCommand(aPP, aCon);
                SqlCommand myMP = new SqlCommand(aMem, aCon);
                SqlCommand myMw = new SqlCommand(aMM, aCon);
                aCon.Open();
                if (txtMemLogin.Text.Equals("") && (!txtMemLogin.Text.Equals(myUP.ExecuteScalar().ToString()))
                    && (!txtMemLogin.Text.Equals(myMP.ExecuteScalar().ToString()))) //|| 
                {
                    am_In = false;
                    lblLoginName.Text = "Empty or incorrect username";
                }
                else
                {
                    lblLoginName.Text = "";
                }
                if ((txtMemLoginPswd.Text.Equals("")) && (!txtMemLoginPswd.Text.Equals(myPw.ExecuteScalar().ToString()))
                    && (!txtMemLoginPswd.Text.Equals(myMw.ExecuteScalar().ToString())))  // || 
                {
                    am_In = false;
                    lblLoginPsw.Text = "Empty or incorrect password";
                }
                else
                {
                    lblLoginPsw.Text = "";
                }
            }catch(InvalidOperationException)
            {
                 lblLoginPsw.Text = "Usersname or Password not matching";
            }
                aCon.Close();
        }
         return am_In;
    }

    protected int getCookie()
    {
        return result;
    }
       
 }