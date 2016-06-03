using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Registration : System.Web.UI.Page
{
    String aConnectingString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    btnOkRegistration_Click(sender, e);
        //   // saveNewMembers(sender, e);
        //}

    }

     private string genID()
        {
            string memNumber = "0123456789ABCDEFGHIJlmnopqrstuvwxyZ987654321k";
            Random nos = new Random();
            char[] myChar = new char[4];
            for (int x = 0; x < myChar.Length; x++)
            {
                myChar[x] = memNumber[nos.Next(memNumber.Length)];
            }
            return new string(myChar);
        }
    private void saveNewMembers()
    {
       SqlConnection myConnect = new SqlConnection(aConnectingString);
        myConnect.Open();
        int count = 0;
        string sex;
        string pro;
        using (SqlCommand command = new SqlCommand("Select count(*) from Members", myConnect))
        {
            count = (int)command.ExecuteScalar();
            count = count + 1;
        }

        using (SqlCommand cmdInsert = new SqlCommand
        ("insert into Members"+
        "(ID,Firstname,Surname,Usersname,Passwords,ConfirmPswd,Email,Gender,Residence, Location, City,ProOption)"  
         + "values(@ID,@Fname,@Sname,@Uname,@Pass, @ConfPsd,@Email,@Gender,@Resid, @Loctn,@City, @Prof)", myConnect))
        {

            if (CheckBoxMale.Checked || CheckBoxFemale.Checked)
            {
                sex = "1";
            }
            else
            {
                sex = "0";
            }
            if(ChkBProYes.Checked)
            {
                pro = "1";
               // loadProfessionalInput(pro);
            }
            else
            {
                pro = "0";
                
            }

            cmdInsert.Parameters.AddWithValue("@ID", genID());
            cmdInsert.Parameters.AddWithValue("@Fname", txtNewMemfirstname.Text);
            cmdInsert.Parameters.AddWithValue("@Sname", txtNewMemlastname.Text);
            cmdInsert.Parameters.AddWithValue("@Uname", txtNewMemUsersname.Text);
            cmdInsert.Parameters.AddWithValue("@Pass", txtNewMemPswd.Text);
            cmdInsert.Parameters.AddWithValue("@ConfPsd", txtNMemConfPswd.Text);
            cmdInsert.Parameters.AddWithValue("@Email", txtEmailAdd.Text);
            cmdInsert.Parameters.AddWithValue("@Gender", sex);
            cmdInsert.Parameters.AddWithValue("@Resid", txtAddress.Text);
            cmdInsert.Parameters.AddWithValue("@Loctn", txtLocation.Text);
            cmdInsert.Parameters.AddWithValue("@City", txtCity.Text);
            cmdInsert.Parameters.AddWithValue("@Prof", pro);

            loadProfessionalInput(pro);

            cmdInsert.ExecuteNonQuery();
            
        }

        myConnect.Close();
       
    }

    private void loadProfessionalInput(string x)
    {
         string status = x;
        if (x.Equals("1"))
        {
             string pro = aConnectingString;
             SqlConnection myConnect = new SqlConnection(aConnectingString);
        myConnect.Open();
        int count = 0;
        string sex;
        
        using (SqlCommand command = new SqlCommand("Select count(*) from Members", myConnect))
        {
            count = (int)command.ExecuteScalar();
            count = count + 1;
        }

        using (SqlCommand cmdInsert = new SqlCommand
        ("insert into Professionals" +
        "(ID,Firstname,Surname,Usersname,Passwords,Email,Gender,Residence, Location, City, ProOption)"
         + "values(@ID,@Fname,@Sname,@Uname,@Pass, @Email,@Gender,@Resid, @Loctn,@City, @Prof)", myConnect))
        {

            if (CheckBoxMale.Checked || CheckBoxFemale.Checked)
            {
                sex = "1";
            }
            else
            {
                sex = "0";
            }

            cmdInsert.Parameters.AddWithValue("@ID", genID());
            cmdInsert.Parameters.AddWithValue("@Fname", txtNewMemfirstname.Text);
            cmdInsert.Parameters.AddWithValue("@Sname", txtNewMemlastname.Text);
            cmdInsert.Parameters.AddWithValue("@Uname", txtNewMemUsersname.Text);
            cmdInsert.Parameters.AddWithValue("@Pass", txtNewMemPswd.Text);
            // cmdInsert.Parameters.AddWithValue("@ConfPsd", txtNMemConfPswd.Text);
            cmdInsert.Parameters.AddWithValue("@Email", txtEmailAdd.Text);
            cmdInsert.Parameters.AddWithValue("@Gender", sex);
            cmdInsert.Parameters.AddWithValue("@Resid", txtAddress.Text);
            cmdInsert.Parameters.AddWithValue("@Loctn", txtLocation.Text);
            cmdInsert.Parameters.AddWithValue("@City", txtCity.Text);
            cmdInsert.Parameters.AddWithValue("@Prof", status);

            cmdInsert.ExecuteNonQuery();

            /*using (SqlConnection aProf = new SqlConnection(pro))
           {

               SqlCommand aCmd = new SqlCommand("NewMemResgistered", aProf);
           aCmd.CommandType = CommandType.StoredProcedure;
           if (CheckBoxMale.Checked || CheckBoxFemale.Checked)
           {
               status = "1";
           }
           else
           {
               status = "0";
           }
           SqlParameter ID = new SqlParameter("@ID", genID() );
           SqlParameter firstname = new SqlParameter("@FirstName", txtNewMemfirstname.Text);
           SqlParameter surname = new SqlParameter("@Surname", txtNewMemlastname.Text);
           SqlParameter username = new SqlParameter("@Usersname", txtNewMemUsersname.Text);
           SqlParameter password = new SqlParameter("@Passwords", txtNewMemPswd.Text);
           SqlParameter email = new SqlParameter("@Email", txtEmailAdd.Text);
           SqlParameter gender = new SqlParameter("@Gender", status);
           SqlParameter residence = new SqlParameter("@Residence", txtAddress.Text);
           SqlParameter location = new SqlParameter("@Location", txtLocation.Text);
           SqlParameter city = new SqlParameter("@City", txtCity.Text);
           aCmd.Parameters.Add(ID);
           aCmd.Parameters.Add(firstname);
           aCmd.Parameters.Add(surname);
           aCmd.Parameters.Add(username);
           aCmd.Parameters.Add(password);
           aCmd.Parameters.Add(email);
           aCmd.Parameters.Add(gender);
           aCmd.Parameters.Add(residence);
           aCmd.Parameters.Add(location);
           aCmd.Parameters.Add(city);
           aProf.Open();
           aCmd.ExecuteNonQuery();

           }*/
        }
        myConnect.Close();
            Response.Redirect("AmProfessional.aspx");
        }

    }

    private bool validateForm()
    {
        bool valid = true;

        if (string.IsNullOrEmpty(txtNewMemfirstname.Text))  
        {
            valid = false;
            lblRname.Text = "Firstname required";
        }
        else
        {
            lblRname.Text = "";
        }
        if (string.IsNullOrEmpty(txtNewMemlastname.Text))    
        {
            valid = false;
            lblRsurname.Text = "Lastname required";
        }
        else
        {
            lblRsurname.Text = "";

        }
        if (string.IsNullOrEmpty(txtNewMemUsersname.Text))
        {
            valid = false;
            lblRusername.Text = "username required";
        }
        else
        {
            lblRusername.Text = "";

        }
        if (string.IsNullOrEmpty(txtNewMemPswd.Text))
        {
            valid = false;
            lblRpassword.Text = "password required";
        }
        else
        {
            lblRpassword.Text = "";

        }
        if (string.IsNullOrEmpty(txtEmailAdd.Text))
        {
            valid = false;
            lblRemail.Text = "Email required";
        }
        else
        {
            lblRemail.Text = "";

        }
        if ((CheckBoxMale.Checked == true) || (CheckBoxFemale.Checked == true))
        {

            lblRcheckboxes.Text = "";
        }
        else
        {
            lblRcheckboxes.Text = "Pick a gender";
            valid = false;

        }
        if (string.IsNullOrEmpty(txtAddress.Text))
        {
            valid = false;
            lblRaddress.Text = "Address required";
        }
        else
        {
            lblRaddress.Text = "";

        }
        if (string.IsNullOrEmpty(txtLocation.Text))
        {
            valid = false;
            lblRloc.Text = "Location required";
        }
        else
        {
            lblRloc.Text = "";

        }
        if (string.IsNullOrEmpty(txtCity.Text))
        {
            valid = false;
            lblRcit.Text = "City required";
        }
        else
        {
            lblRcit.Text = "";

        }

        return valid;

    }

    protected void btnOkRegistration_Click(object sender, EventArgs e)
    {
       
        //Response.Redirect("ScheduleAppointment.aspx");
        if (validateForm())
        {
            saveNewMembers();
            Response.Redirect("RegistrationSuccess.aspx");
    
        }    
    }

}

/* string newMem = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";
        using(SqlConnection mem = new SqlConnection(newMem))
        {
            SqlCommand aComd = new SqlCommand("NewMemRegistered", mem);
            aComd.CommandType = CommandType.StoredProcedure;
            SqlParameter id = new SqlParameter("@ID", genID());
            SqlParameter Firstname = new SqlParameter("@Firstname", txtNewMemfirstname);
            SqlParameter Surname = new SqlParameter("@Surname",txtNewMemlastname);
            SqlParameter Usersname = new SqlParameter("@Usersname",txtNewMemUsersname);
            SqlParameter Password = new SqlParameter("@Password", txtNewMemPswd);
            SqlParameter ConfirmPassword = new SqlParameter("@ConfirmPswd", txtNMemConfPswd);
            SqlParameter Email = new SqlParameter("@Email", txtEmailAdd);
            SqlParameter Gender = new SqlParameter("@Gender", CheckBox());
            SqlParameter Residence = new SqlParameter("@Residence", txtAddress );
            SqlParameter Location = new SqlParameter("@Location", txtLocation);
            SqlParameter City = new SqlParameter("@City", txtCity);
            SqlParameter POption = new SqlParameter("@ProOption", CheckBoxPro());
            aComd.Parameters.Add(id);
            aComd.Parameters.Add(Firstname);
            aComd.Parameters.Add(Surname);
            aComd.Parameters.Add(Usersname);
            aComd.Parameters.Add(ConfirmPassword);
            aComd.Parameters.Add(Email);
            aComd.Parameters.Add(Gender);
            aComd.Parameters.Add(Residence);
            aComd.Parameters.Add(Location);
            aComd.Parameters.Add(City);
            aComd.Parameters.Add(POption);
            mem.Open();
            aComd.ExecuteNonQuery();*/