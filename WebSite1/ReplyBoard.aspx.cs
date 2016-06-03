using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ReplyBoard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Prof"] != null && Request.Cookies["Log"] != null)
        {
            string title =  Request.Cookies["Prof"]["Profession"].ToString();
            string user = Request.Cookies["Log"]["Usersname"].ToString();
            lblCurrentUser.Text = title + "  " + user;

            //lblCurrentUser.Text = Request.Cookies["Log"]["Usersname"].ToString();
        }
        else
        {

            Response.Redirect("login.aspx");
        }
    }
    protected void btnReadApptmt_Click(object sender, EventArgs e)
    {
        //need for conditions here
        Response.Redirect("ReadAppointmentSchedules.aspx");
    }
    protected void btnReadVisit_Click(object sender, EventArgs e)
    {
        //need for conditions here
        Response.Redirect("ReadVisitationSchedules.aspx");
    }
    protected void btnReadOthers_Click(object sender, EventArgs e)
    {
        //need for conditions here
        Response.Redirect("ReadOtherSchedules.aspx");
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
}