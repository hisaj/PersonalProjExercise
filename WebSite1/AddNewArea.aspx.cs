using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AddNewArea : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if(IsPostBack)    
         {
             if(LocationSet())
             saveArea();
             txtAddNLoc.Text = "";
             txtAddNcity.Text = string.Empty;
         }
    }

     private void saveArea()
    {
        string cs = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\ExpressAppointment.mdf;Integrated Security=True";
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("myArea", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paramID = new SqlParameter("@id", RandomIdentityNumber());
            SqlParameter paramLocation = new SqlParameter("@Location", txtAddNLoc.Text);
            SqlParameter paramCity = new SqlParameter("@City", txtAddNcity.Text);
            cmd.Parameters.Add(paramID);
            cmd.Parameters.Add(paramLocation);
            cmd.Parameters.Add(paramCity);
            con.Open();
            cmd.ExecuteNonQuery();
        }

    }

    private string RandomIdentityNumber()
    {
        Random theNum = new Random();
        string range = "abcdefghijklMNOPQRSTUVWXYZ01234ABCDEFGHIJKLmnopqrstuvwxyz56789";
        char[] aChar = new char[5];
        for (int x = 0; x < aChar.Length; x++)
        {
            aChar[x] = range[theNum.Next(range.Length)];
        }
        return new string(aChar);
    }

     private bool LocationSet()
     {
        bool check = true;

        if (string.IsNullOrEmpty(txtAddNLoc.Text))  // && !string.IsNullOrEmpty(txtAddNcity.Text))
        {
            check = false;
            lblNLErMsg.Text = "You must add a Location";
        }
        else
         {
            lblNLErMsg.Text = "";
         }
       if (string.IsNullOrEmpty(txtAddNcity.Text))    // && string.IsNullOrEmpty(txtAddNcity.Text))
        {
            check = false;
            lblNciErmsg.Text = "You must add a City";
        }
         else
         {
             lblNciErmsg.Text = "";

         }
        return check;

    }

     protected void btnAddLoc_Click(object sender, EventArgs e)
    {
        
           txtAddNLoc.Text = "";
    }

    protected void btnAddCity_Click(object sender, EventArgs e)
    {
      
            txtAddNcity.Text = string.Empty;
    }
   
}