using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Cookies["Usersname"].Expires = DateTime.Now.AddDays(-1);


        //HttpCookie mylogin = new HttpCookie("Log");
        //mylogin.Expires = DateTime.Now.AddHours(-1);
        //Response.Cookies.Add(mylogin);

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetNoStore();

        Response.Redirect("login.aspx");
        //Response.Redirect(clsCommon.value("login.aspx?mode=logout");
    }
}