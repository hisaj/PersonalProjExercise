using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class BookAppointment : System.Web.UI.Page
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
    protected void btnGetAppID_Click(object sender, EventArgs e)
    {
        // 
        string aid = "select ID from Members where usersname = '" + lblCurrentUser.Text + "'";
        using (SqlConnection myaId = new SqlConnection(aConnectingString))
        {
            SqlCommand fetchAId = new SqlCommand(aid, myaId);
            myaId.Open();
            //fetchId.ExecuteNonQuery();
            lblShowMemAppSchdID.Text = fetchAId.ExecuteScalar().ToString(); // display the value of the ID row with corresponding Label
            getData();
            myaId.Close();
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
                txtSchdSurName.Text = (myReader["Surname"].ToString());
                txtScFirName.Text = (myReader["FirstName"].ToString());
               // ddlSchdTime.SelectedItem.Text = (myReader["time"].ToString());
                txtSchdLoc.Text = (myReader["Location"].ToString());
                txtSchdCity.Text = (myReader["City"].ToString());
                //ddlSchdDay.SelectedItem.Text = (myReader["day"].ToString());
            }
            acon.Close();
        }
       
    }

    private void saveAppointments()
    {
        string medC, opH, opGP;
        string schedule = "Insert into Appointments" + "(Id, Hospital, GP, Lastname, Firstname, DOB, Reasons, ChoiceTime, Location, City, ChosenDay, MedicalCard)"
         + "values(@Id, @Hosp, @GP,@LastN,@Fname,@dob,@why, @time,@loc,@cit,@day,@mdc)";

        using (SqlConnection getCon = new SqlConnection(aConnectingString))
        {
            SqlCommand input = new SqlCommand(schedule, getCon);

            getCon.Open();
            if (ChkBoxMedYes.Checked && !ChkBoxMedNo.Checked)
            {
                medC = "1";
            }
            else
            {
                medC = "0";

            }
            if (CheckBoxHospital.Checked) // ||
            {
                opH = "1";
            }
            else
            {
                opH = "0";

            }
            if (CheckBoxGP.Checked)
            {
                opGP = "1";
            }
            else
            {
                opGP = "0";
            }

            input.Parameters.AddWithValue("@Id", lblShowMemAppSchdID.Text);
            input.Parameters.AddWithValue("@Hosp", opH);
            input.Parameters.AddWithValue("@GP", opGP);
            input.Parameters.AddWithValue("@LastN", txtSchdSurName.Text);
            input.Parameters.AddWithValue("@Fname", txtScFirName.Text);
            input.Parameters.AddWithValue("@dob", txtSchdDOB.Text);
            input.Parameters.AddWithValue("@why", txtSchdReason.Text);
            input.Parameters.AddWithValue("@time", ddlSchdTime.SelectedItem.Text);
            input.Parameters.AddWithValue("@loc", txtSchdLoc.Text);
            input.Parameters.AddWithValue("@cit", txtSchdCity.Text);
            input.Parameters.AddWithValue("@day", ddlSchdDay.SelectedItem.Text);
            input.Parameters.AddWithValue("@mdc", medC);

            input.ExecuteNonQuery();
            getCon.Close();
        }
        reset();
    }

    private bool updateAppointment()
    {
        bool UpdateApp = false;
        string reset = "Update Appointments set DOB= '" + txtSchdDOB.Text + "', Reasons= '" + txtSchdReason.Text + "', ChoiceTime= '" + ddlSchdTime.SelectedValue + "', Location= '" + txtSchdLoc.Text + "', City= '" + txtSchdCity.Text + "', ChosenDay= '" + ddlSchdDay.SelectedValue + "' where Id= '" + lblShowMemAppSchdID.Text + "'";
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
    }

    private void saveAppointmentsHistory()
    {
        string medC, opH, opGP;
        string schedule = "Insert into TraceSchedules" + "(Id, Hospital, GP, Lastname, Firstname, DOB, Reasons, ChoiceTime, Location, City, ChosenDay, MedicalCard, Period)"
         + "values(@Id, @Hosp, @GP,@LastN,@Fname,@dob,@why, @time,@loc,@cit,@day,@mdc, getdate())";

        using (SqlConnection getCon = new SqlConnection(aConnectingString))
        {
            SqlCommand input = new SqlCommand(schedule, getCon);

            getCon.Open();
            if (ChkBoxMedYes.Checked && !ChkBoxMedNo.Checked)
            {
                medC = "1";
            }
            else
            {
                medC = "0";

            }
            if (CheckBoxHospital.Checked) // ||
            {
                opH = "1";
            }
            else
            {
                opH = "0";

            }
            if (CheckBoxGP.Checked)
            {
                opGP = "1";
            }
            else
            {
                opGP = "0";
            }

            input.Parameters.AddWithValue("@Id", lblShowMemAppSchdID.Text);
            input.Parameters.AddWithValue("@Hosp", opH);
            input.Parameters.AddWithValue("@GP", opGP);
            input.Parameters.AddWithValue("@LastN", txtSchdSurName.Text);
            input.Parameters.AddWithValue("@Fname", txtScFirName.Text);
            input.Parameters.AddWithValue("@dob", txtSchdDOB.Text);
            input.Parameters.AddWithValue("@why", txtSchdReason.Text);
            input.Parameters.AddWithValue("@time", ddlSchdTime.SelectedItem.Text);
            input.Parameters.AddWithValue("@loc", txtSchdLoc.Text);
            input.Parameters.AddWithValue("@cit", txtSchdCity.Text);
            input.Parameters.AddWithValue("@day", ddlSchdDay.SelectedItem.Text);
            input.Parameters.AddWithValue("@mdc", medC);
            input.ExecuteNonQuery();
            getCon.Close();
        }
        reset();
    }

    protected void btnSchdOk_Click(object sender, EventArgs e)
    {
        if (validateForm() )
        {
            //saveAppointments();

            saveAppointmentsHistory();
            //Response.Redirect("ScheduleAppointment.aspx");
        }
        else
        {
            //saveAppointmentsHistory();
           // saveAppointments();&& updateAppointment()
        }
        Response.Redirect("ScheduleAppointment.aspx");
    }

    private bool validateForm()
    {
        bool check = true;
        if (!(CheckBoxHospital.Checked || CheckBoxGP.Checked || ChkBoxMedYes.Checked || ChkBoxMedYes.Checked))
        {
            check =false;
            lblAppValidation.Text = "One or more CheckBox required is empty";
        }
        else
        
        if ((string.IsNullOrEmpty(txtSchdSurName.Text)) || (string.IsNullOrEmpty(txtScFirName.Text)) || (string.IsNullOrEmpty(txtSchdDOB.Text))
            || (string.IsNullOrEmpty(txtSchdReason.Text)) || (string.IsNullOrEmpty(txtSchdLoc.Text)) || (string.IsNullOrEmpty(txtSchdCity.Text)))
        {
            check = false;
            lblAppValidation.Text = "One or more data required is empty";
        }
        else
        
        if ((ddlSchdTime.SelectedIndex == 0) || ( ddlSchdDay.SelectedIndex == 0))
        {
            check = false;
            lblAppValidation.Text = "Your Time or Day is not selected";
        }
        else
        
            lblAppValidation.Text = "";
        

        return check;
    }

    private void reset()
    {
        lblShowMemAppSchdID.Text = "";
        CheckBoxHospital.Checked = false;
        CheckBoxGP.Checked = false;
        txtSchdSurName.Text = "";
        txtScFirName.Text = "";
        txtSchdDOB.Text = "";
        txtSchdReason.Text = "";
        ddlSchdTime.SelectedIndex = 0;
        txtSchdLoc.Text = "";
        txtSchdCity.Text = "";
        ddlSchdDay.SelectedIndex = 0;
        ChkBoxMedYes.Checked = false;
        ChkBoxMedNo.Checked = false;
        lblAppValidation.Text = "";
    }

    protected void btnCanelApp_Click(object sender, EventArgs e)
    {
        reset();      
    }
    protected void btnCheckReplies_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReplyBoard.aspx");
    }
}


/* CREATE TRIGGER [ScheduleHistory]
	ON [dbo].[Appointments]
	AFTER INSERT
	AS
	BEGIN
		SET NOCOUNT ON

			Declare  @Id  VARCHAR (5) 
			Declare @Hospital bit
			Declare @GP bit 
			Declare  @Lastname VARCHAR (15)
			Declare  @Firstname   VARCHAR (15)
			Declare  @DOB   NVARCHAR (9)
			Declare  @Reasons   NVARCHAR (60)
			Declare  @ChoiceTime Time
			Declare @Location    VARCHAR (15) 
			Declare @City        VARCHAR (15) 
			Declare  @ChosenDay  Text 
			Declare @MedicalCard   bit 
			Declare @Period datetime
	    
		Select @Id = INSERTED.Id From INSERTED
		Select @Hospital = INSERTED.Hospital From INSERTED
		Select @GP = INSERTED.GP From INSERTED
		Select @Lastname = INSERTED.Lastname From INSERTED
		Select @Firstname = INSERTED.Firstname From INSERTED
		Select @DOB = INSERTED.DOB From INSERTED
		Select @Reasons = INSERTED.Reasons From INSERTED
		Select @choiceTime = INSERTED.ChoiceTime From INSERTED
		Select @Location = INSERTED.Location From INSERTED
		Select @City = INSERTED.City From INSERTED
		Select @ChosenDay = INSERTED.ChosenDay From INSERTED
		Select @MedicalCard = INSERTED.MedicalCard From INSERTED
		
		INSERT INTO TraceSchedules (Id, Hospital, GP, Lastname, Firstname, DOB, Reasons, ChoiceTime, Location, City, MedicalCard, Period)
		values (@Id,@Hospital,@GP,@Lastname,@Firstname,@DOB,@Reasons,@ChoiceTime,@Location,@City,@MedicalCard,getdate())
		
	END

 * 
 * 
 *  private void saveAppointments()
    {
        string medC, opH, opGP;
        string schedule = "Insert into TraceSchedules" + "(Id, Hospital, GP, Lastname, Firstname, DOB, Reasons, ChoiceTime, Location, City, ChosenDay, MedicalCard,Period)"
         + "values(@Id, @Hosp, @GP,@LastN,@Fname,@dob,@why, @time,@loc,@cit,@day,@mdc, getdate())";

        using (SqlConnection getCon = new SqlConnection(aConnectingString))
        {
            SqlCommand input = new SqlCommand(schedule, getCon);

            getCon.Open();
            if (ChkBoxMedYes.Checked && !ChkBoxMedNo.Checked)
            {
                medC = "1";
            }
            else
            {
                medC = "0";

            }
            if (CheckBoxHospital.Checked) // ||
            {
                opH = "1";
            }
            else
            {
                opH = "0";

            }
            if (CheckBoxGP.Checked)
            {
                opGP = "1";
            }
            else
            {
                opGP = "0";
            }

            input.Parameters.AddWithValue("@Id", lblShowMemAppSchdID.Text);
            input.Parameters.AddWithValue("@Hosp", opH);
            input.Parameters.AddWithValue("@GP", opGP);
            input.Parameters.AddWithValue("@LastN", txtSchdSurName.Text);
            input.Parameters.AddWithValue("@Fname", txtScFirName.Text);
            input.Parameters.AddWithValue("@dob", txtSchdDOB.Text);
            input.Parameters.AddWithValue("@why", txtSchdReason.Text);
            input.Parameters.AddWithValue("@time", ddlSchdTime.SelectedItem.Text);
            input.Parameters.AddWithValue("@loc", txtSchdLoc.Text);
            input.Parameters.AddWithValue("@cit", txtSchdCity.Text);
            input.Parameters.AddWithValue("@day", ddlSchdDay.SelectedItem.Text);
            input.Parameters.AddWithValue("@mdc", medC);

            input.ExecuteNonQuery();
            getCon.Close();
        }
        reset();
    }
 * 
 * 
 * 
 * private void updateTable()
    {
        string medC, opH, opGP;
         if (ChkBoxMedYes.Checked && !ChkBoxMedNo.Checked)
                    {
                        medC = "1";
                        // loadProfessionalInput(pro);
                    }
                    else
                    {
                        medC = "0";

                    }
                    if (CheckBoxHospital.Checked) // ||
                    {
                        opH = "1";
                        // loadProfessionalInput(pro);
                    }
                    else
                    {
                        opH = "0";

                    }
                    if (CheckBoxGP.Checked)
                    {
                        opGP = "1";
                    }
                    else
                    {
                        opGP = "0";
                    }


        string play = "Update AppTrial set Hospital = '" +opH +"' and set GP = '" + opGP +"'  Lastname = '" + txtSchdSurName.Text + "'"+
        " Firstname = '" + txtScFirName.Text + "' DOB = '" + txtSchdDOB.Text + "' Reasons = '" + txtSchdReason.Text + "' ChoiceTime = '" + ddlSchdTime.SelectedItem.Text + "'" +
         " Location = '" + txtSchdLoc.Text + "' City = '" + txtSchdCity.Text + "'" +
        " ChosenDay = '" + ddlSchdDay.SelectedItem.Text + "' MedicalCard = '" + medC +"' where Id = '" + lblShowMemAppSchdID.Text + "'";

        //string schedule = "Update Appointmenmts  set Hospital =  @Hosp, GP = @GP,Lastname=@LastN, Firstname= @Fname, DOB=@dob, Reasons=@why," +
        //"ChoiceTime=@time,Location=@loc,City=@cit,ChosenDay=@day,MedicalCard=@mdc";
        using (SqlConnection getCon = new SqlConnection(aConnectingString))
        {
            SqlCommand input = new SqlCommand(play, getCon);

            getCon.Open();
            if (ChkBoxMedYes.Checked && !ChkBoxMedNo.Checked)
            {
                medC = "1";
                // loadProfessionalInput(pro);
            }
            else
            {
                medC = "0";

            }
            if (CheckBoxHospital.Checked) // ||
            {
                opH = "1";
                // loadProfessionalInput(pro);
            }
            else
            {
                opH = "0";

            }
            if (CheckBoxGP.Checked)
            {
                opGP = "1";
            }
            else
            {
                opGP = "0";
            }
            input.Parameters.AddWithValue("@Id", lblShowMemAppSchdID.Text);
            input.Parameters.AddWithValue("@Hosp", opH);
            input.Parameters.AddWithValue("@GP", opGP);
            input.Parameters.AddWithValue("@LastN", txtSchdSurName.Text);
            input.Parameters.AddWithValue("@Fname", txtScFirName.Text);
            input.Parameters.AddWithValue("@dob", txtSchdDOB.Text);
            input.Parameters.AddWithValue("@why", txtSchdReason.Text);
            input.Parameters.AddWithValue("@time", ddlSchdTime.SelectedItem.Text);
            input.Parameters.AddWithValue("@loc", txtSchdLoc.Text);
            input.Parameters.AddWithValue("@cit", txtSchdCity.Text);
            input.Parameters.AddWithValue("@day", ddlSchdDay.SelectedItem.Text);
            input.Parameters.AddWithValue("@mdc", medC);
            input.ExecuteNonQuery();
            getCon.Close();
        }
    }*/