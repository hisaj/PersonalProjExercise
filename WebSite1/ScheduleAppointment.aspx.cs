using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class ScheduleAppointment : System.Web.UI.Page
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
    protected void btnCheckReplies_Click(object sender, EventArgs e)
    {
        //need for conditions here
        Response.Redirect("MyResponses.aspx");
    }

   
    protected void btnSchApp_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookAppointment.aspx");
    }
    protected void btnSchVisit_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookVisitation.aspx");
    }
    protected void btnSchOthers_Click(object sender, EventArgs e)
    {
        Response.Redirect("QueryConcerns.aspx");
    }
    protected void btnSignOut_Click(object sender, EventArgs e)
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
/* 
   private void PopulateFields()
{
  using(SqlConnection con1 = new SqlConnection("Data Source=USER-PC;Initial Catalog=webservice_database;Integrated Security=True"))
  {
    DataTable dt = new DataTable();
    con1.Open();
    SqlDataReader myReader = null;  
    SqlCommand myCommand = new SqlCommand("select * from customer_registration where username='" + Session["username"] + "'", con1);

    myReader = myCommand.ExecuteReader();

    while (myReader.Read())
    {
        TextBoxPassword.Text = (myReader["password"].ToString());
        TextBoxRPassword.Text = (myReader["retypepassword"].ToString());
        DropDownListGender.SelectedItem.Text = (myReader["gender"].ToString());
        DropDownListMonth.Text = (myReader["birth"].ToString());
        DropDownListYear.Text = (myReader["birth"].ToString());
        TextBoxAddress.Text = (myReader["address"].ToString());
        TextBoxCity.Text = (myReader["city"].ToString());
        DropDownListCountry.SelectedItem.Text = (myReader["country"].ToString());
        TextBoxPostcode.Text = (myReader["postcode"].ToString());
        TextBoxEmail.Text = (myReader["email"].ToString());
        TextBoxCarno.Text = (myReader["carno"].ToString());
    }
    con1.Close();
  }//end using
}
 * protected void Button1_Click(object sender, EventArgs e)
{
    SqlConnection con = new SqlConnection("Data Source=USER-PC;Initial Catalog=webservice_database;Integrated Security=True");
    SqlCommand cmd = new SqlCommand("UPDATE customer_registration SET password = @password, retypepassword = @retypepassword, 
  gender = @gender, birth = @birth, address = @address, city = @city, country = @country, postcode = @postcode, email = @email,
 carno = @carno where username='" + Session["username"] + "'", con);
    con.Open();

    cmd.Parameters.AddWithValue("@password", TextBoxPassword.Text);
    cmd.Parameters.AddWithValue("@retypepassword", TextBoxRPassword.Text);
    cmd.Parameters.AddWithValue("@gender", DropDownListGender.Text);
    cmd.Parameters.AddWithValue("@birth", DropDownListDay.Text + DropDownListMonth.Text + DropDownListYear.Text);
    cmd.Parameters.AddWithValue("@address", TextBoxAddress.Text);
    cmd.Parameters.AddWithValue("@city", TextBoxCity.Text);
    cmd.Parameters.AddWithValue("@country", DropDownListCountry.Text);
    cmd.Parameters.AddWithValue("@postcode", TextBoxPostcode.Text);
    cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text);
    cmd.Parameters.AddWithValue("@carno", TextBoxCarno.Text);

    cmd.ExecuteNonQuery();
    con.Close();
    if (IsPostBack)
    {
        Response.Redirect("UpdateSuccess.aspx");
    }
}
    */

/* public partial class User
{
    public int UserID{get;set;}
    public string UserName{get;set;}
    public DateTiem TimeStamp{get;set;}
}
 
 User user = new User{UserName = "xyz", TimeStamp = DateTime.Now};
MyDataContext context = new MyDataContext();
context.Users.InsertOnSubmit(user);
context.SubmitChanges();*/