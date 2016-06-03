using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /*protected void logout_OnClick(object sender, EventArgs e)

{   Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
        Response.Cookies["User"].Expires = DateTime.Now.AddDays(-1);

Session.Abandon();

Response.Redirect("login.aspx");
}

protected void Page_Init(object sender, EventArgs e)

{

Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
 Response.Cache.SetCacheability(HttpCacheability.NoCache);
Response.Cache.SetNoStore();

}*/
}
