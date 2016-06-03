using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Home : System.Web.UI.Page
{
    SqlConnection aConnection = new SqlConnection();
    SqlCommand aCommand = new SqlCommand();
    SqlCommand theCommand = new SqlCommand();
    DataSet DataLocation = new DataSet();
    DataSet DataSetAttributes = new DataSet();
    DataSet DataCity = new DataSet();
    SqlDataAdapter aDataAdapter = new SqlDataAdapter();
    String aConnectionString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
             DropDownListLocation();
             btnContinue.Enabled = false;
        }
    }

    protected void btnLocGo_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            DropDownListCity();
            //ddlCity_SelectedIndexChanged(sender, e);
        }
    }

    protected void ddlLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
      /*  string loadLoc = aConnectionString;
        //using (SqlConnection Upcon = new SqlConnection(loadLoc))
        //{
        //    SqlCommand cmd = new SqlCommand("Select distinct Location from LocCity", Upcon);

        //    Upcon.Open();
        //    ddlLocation.DataSource = cmd.ExecuteReader();
        //    ddlLocation.DataTextField = "Location";
        //    ddlLocation.DataValueField = "Location";
        //    ddlLocation.DataBind();
        //}
      */  
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        string loadcit = aConnectionString;
        DataSet loc = new DataSet();
        SqlDataAdapter myda = new SqlDataAdapter("Select city  FROM locCity where Location = '" + ddlLocation.SelectedValue + "'", loadcit);
        myda.Fill(loc);
        ddlCity.DataSource = loc;
        ddlCity.DataValueField = "City";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("Select City", "0"));
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        if (IsPostBack && picLocCity())
        {
            Response.Redirect("ScheduleAppointment.aspx");
            // Response.Redirect("login.aspx");
        }
        else
            Response.Write("Pick a Location and City");
    }

    protected bool picLocCity(){
        bool myArea = true;
        if ((ddlLocation.SelectedIndex == 0) && (ddlCity.SelectedIndex == 0))   // ||
        {
            myArea = false;
        }
        //if (ddlCity.SelectedIndex == 0)
        //{
        //    myArea = false;
        //}
        else
            myArea= true;

        return myArea;
    }

    //method to load the available location in the database into the dropdownlist
    private void DropDownListLocation()
    {
        string loadLoc = aConnectionString;
        using (SqlConnection Upcon = new SqlConnection(loadLoc))
        {
            SqlCommand cmd = new SqlCommand("Select distinct Location from LocCity", Upcon); 

            Upcon.Open();
            ddlLocation.DataSource = cmd.ExecuteReader();
            ddlLocation.DataTextField = "Location";
            ddlLocation.DataValueField = "Location";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("Select Location", "0"));
        }
    }

     private void DropDownListCity()
     {
        string loadCiti = aConnectionString;
        string query = "Select  City from LocCity where location = '" + ddlLocation.SelectedValue + "'";
        using (SqlConnection citi = new SqlConnection(loadCiti))
        {
            SqlCommand dmc = new SqlCommand(query, citi);
            //SqlCommand dmc = new SqlCommand(cities, citi);
            citi.Open();
            ddlCity.DataSource = dmc.ExecuteReader();
            ddlCity.DataTextField = "City";
            ddlCity.DataValueField = "City";
            ddlCity.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("Select City", "0"));
            btnContinue.Enabled = true;
        }
     }

     private bool MemOption()
     {
        
         bool checkmem = false;
         HttpCookie mylogin = new HttpCookie("Log");
         string getLog = "Select * from Members where Usersname = '" + mylogin["Usersname"] + "'";
         SqlConnection entry = new SqlConnection(aConnectionString);
         SqlDataAdapter mine = new SqlDataAdapter(getLog, entry);
         DataTable mem = new DataTable();
         mine.Fill(mem);

         if (mem.Rows.Count.ToString() == "1")
         {
            
             mylogin["Usersname"] = mem.Rows[0]["Usersname"].ToString();
             mylogin.Expires = DateTime.Now.AddHours(1);
             Response.Cookies.Add(mylogin);
             checkmem = true;
            
              Response.Redirect("ScheduleAppointment.aspx");
         }
         return checkmem;
     }

    protected void btnFillNewArea_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddNewArea.aspx");
    }
   
   /* protected void btnLogout_Click(object sender, EventArgs e)
    {
        HttpCookie mylogin = new HttpCookie("Log");
        mylogin.Expires = DateTime.Now.AddHours(-1);
        Response.Cookies.Add(mylogin);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();
        Response.Redirect("login.aspx");
    }*/
}
