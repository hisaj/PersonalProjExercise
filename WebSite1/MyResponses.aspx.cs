using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class MyResponses : System.Web.UI.Page
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

    //Method1 to display Appointment data from database table onto the gridview and output a message to users
    private void retrieveDataApp()
    {
        using (SqlConnection con = new SqlConnection(aConnectingString))
        {
            using (SqlCommand cmd = new SqlCommand("Select Id, Lastname, Firstname, Reasons, AppAccept from TraceSchedules Where AppAccept is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')"))
            {
                SqlCommand getValue = new SqlCommand("select AppAccept from TraceSchedules where AppAccept is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')", con);
              //  SqlCommand getUser = new SqlCommand("select Usersname from Members where Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')", con);  
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                     con.Open();
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        if (ValidateAppointment())
                        {
                            lblViewResultForAll.Text = "Your appointment has been accepted by " + getValue.ExecuteScalar().ToString();
                        }
                        else
                            retrieveDataAppCancel();
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                con.Close();
            }
        }
    }

    //Method2 to display Visitation data from database table onto the gridview and output a message to users
    private void retrieveDataVisit()
    {
        string outputVisit = "select AcceptCol from Visitations where AcceptCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
       // string visitName = "select Usersname from Members where Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
        string displayAppResp = "Select Id, Lastname, Firstname, Reasons, AcceptCol from Visitations Where AcceptCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "') ";
        using (SqlConnection disp = new SqlConnection(aConnectingString))
        {
            SqlCommand sqlCommand = new SqlCommand(displayAppResp, disp);
            //SqlCommand sqlCommand1 = new SqlCommand(visitName, disp);
            SqlCommand fetchVisitView = new SqlCommand(outputVisit, disp);
            SqlDataAdapter myView = new SqlDataAdapter(sqlCommand);
            DataSet view = new DataSet();
            disp.Open();
            // ||
            if (ValidateVisitations())
            {
                lblViewResultForAll.Text = "Your visitation has been accepted by " + fetchVisitView.ExecuteScalar().ToString();
            }
            else
                retrieveDataVisitCancel();
            myView.Fill(view);
            sqlCommand.ExecuteNonQuery();
            GridView2.DataSource = view;
            GridView2.DataBind();
        }
    }

    //Method3 to display Other Query data from database table onto the gridview and output a message to users
    private void retrieveDataOthers()
    {
        string outputOthers = "select AcceptCol from OtherConcerns where AcceptCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
       // string OthersCancel = "select CancelCol from OtherConcerns where CancelCol is not null ";
        using (SqlConnection otherC = new SqlConnection(aConnectingString))
        {
            using (SqlCommand cmd = new SqlCommand("Select Id, DOB, Location, Reasons, AcceptCol from OtherConcerns Where AcceptCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')"))
            {
                SqlCommand myConcern = new SqlCommand(outputOthers, otherC);
               // SqlCommand CanelConcern = new SqlCommand(OthersCancel, otherC);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = otherC;
                     otherC.Open();
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        if(ValidateOtherConcerns())
                        {
                            lblViewResultForAll.Text = "Your Other Query is being looked into by " + myConcern.ExecuteScalar().ToString();
                        }
                        else
                            retrieveDataOthersCancel();
                        sda.Fill(dt);
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                    }
                }
                otherC.Close();
            }
        }
    }


    //Method4 to retrieve Appointment data that was cancel from database table onto the gridview and output a message to users
    private void retrieveDataAppCancel()
    {
        string outputApp = "select AppCancel from TraceSchedules Where  Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
         string compare = "select AppAccept from TraceSchedules Where  Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
        using (SqlConnection conn = new SqlConnection(aConnectingString))
        {
            using (SqlCommand rdac = new SqlCommand("Select Id, Lastname, Firstname, Reasons, AppCancel from TraceSchedules Where AppCancel is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')"))
            {
                SqlCommand myCancel = new SqlCommand(outputApp, conn);
                SqlCommand myColumn = new SqlCommand(compare, conn);
                SqlCommand checkUsers = new SqlCommand("select Usersname from Members where Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')", conn);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    rdac.Connection = conn;
                    conn.Open();
                    sda.SelectCommand = rdac;
                    using (DataTable dtAppCancel = new DataTable()) //||
                    {
                        try
                        {
                            if ((myCancel.ExecuteNonQuery().ToString().Equals("-1")) && !string.IsNullOrEmpty(myCancel.ExecuteScalar().ToString())
                                && lblCurrentUser.Text.Equals(checkUsers.ExecuteScalar().ToString()))
                            {
                                    lblViewResultForAll.Text = "Your appointment has been cancelled by " + myCancel.ExecuteScalar().ToString();
                            }
                            else if ((myCancel.ExecuteNonQuery().ToString().Equals("1")) )
                            {
                                lblViewResultForAll.Text = "You have no appointments schedules to cancel. Rebook your schedules";
                            }
                            else if ((myCancel.ExecuteNonQuery().ToString().Equals("-1") && (string.IsNullOrEmpty(myColumn.ExecuteScalar().ToString()) && (string.IsNullOrEmpty(myCancel.ExecuteScalar().ToString()))
                                && lblCurrentUser.Text.Equals(checkUsers.ExecuteScalar().ToString()))))
                            {
                                 lblViewResultForAll.Text = "Your appointment is still awaiting a feedback, please check again soon ";
                            }
                            else
                                lblViewResultForAll.Text = "Your appointment has been accepted by " + myColumn.ExecuteScalar().ToString();
                         }
                        catch (NullReferenceException)
                        {
                            lblViewResultForAll.Text = "No data found matching your request. You probably have not schedule any ";
                        }
                        sda.Fill(dtAppCancel);
                        GridView1.DataSource = dtAppCancel;
                        GridView1.DataBind();
                    }
                }
                conn.Close();
            }
        }
    }

    //Method5 to retrieve Visitation data that was cancel from database table onto the gridview and output a message to users
    private void retrieveDataVisitCancel()
    {
        string compareV = "select AcceptCol from Visitations Where  Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";

        string resultV = "select CancelCol from Visitations where  Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
        using (SqlConnection con = new SqlConnection(aConnectingString))
        {
            using (SqlCommand rdvc = new SqlCommand("Select Id, Lastname, Firstname, Reasons, CancelCol from Visitations Where CancelCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "') "))
            {
                SqlCommand myCancelV = new SqlCommand(resultV, con);
                SqlCommand myColumnV = new SqlCommand(compareV, con);
                SqlCommand checkUsersV = new SqlCommand("select Usersname from Members where Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')", con);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    rdvc.Connection = con;
                    con.Open();
                    sda.SelectCommand = rdvc;
                    using (DataTable dtVisitCancel = new DataTable())
                    {
                        try
                        {  
                            if ((!myCancelV.ExecuteNonQuery().ToString().Equals("-1")) && !lblCurrentUser.Text.Equals(checkUsersV.ExecuteScalar().ToString()))
                            {
                                lblViewResultForAll.Text = "You have no Visitation schedules to cancel. Rebook your schedules";
                            }
                            else if (!lblCurrentUser.Text.Equals(checkUsersV.ExecuteScalar().ToString()) || (string.IsNullOrWhiteSpace(checkUsersV.ExecuteScalar().ToString()) ))
                            {
                                lblViewResultForAll.Text = "No records found " ;
                            }
                            else if ((myCancelV.ExecuteNonQuery().ToString().Equals("-1")) && !string.IsNullOrEmpty(myCancelV.ExecuteScalar().ToString())
                                 && lblCurrentUser.Text.Equals(checkUsersV.ExecuteScalar().ToString()))
                            { 
                                lblViewResultForAll.Text = "Your Visitation Schedules has been cancelled by " + myCancelV.ExecuteScalar().ToString();
                            }
                       
                            else if ((myCancelV.ExecuteNonQuery().ToString().Equals("-1") && (string.IsNullOrEmpty(myColumnV.ExecuteScalar().ToString()) && (string.IsNullOrEmpty(myCancelV.ExecuteScalar().ToString()))
                                && lblCurrentUser.Text.Equals(checkUsersV.ExecuteScalar().ToString()))))
                            {
                                lblViewResultForAll.Text = "Your Visitation schedules is still awaiting a feedback, please check again soon ";
                            }
                            else  
                                lblViewResultForAll.Text = "Your Visitation has been accepted by " + myColumnV.ExecuteScalar().ToString();                  
                        }
                        catch(NullReferenceException) 
                        { 
                            lblViewResultForAll.Text = "No data found matching your request. You probably have not schedule any ";
                        }
                        sda.Fill(dtVisitCancel);
                        GridView2.DataSource = dtVisitCancel;
                        GridView2.DataBind();
                    }
                }
                con.Close();
            }
        }
    }

    //Method6 to retrieve OtherQuery data that was cancel from database table onto the gridview and output a message to users
    private void retrieveDataOthersCancel()
    {
        string compareO = "select AcceptCol from OtherConcerns Where  Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
        string resultO = "select CancelCol from OtherConcerns where CancelCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
        using (SqlConnection con = new SqlConnection(aConnectingString))
        {
            using (SqlCommand cmd = new SqlCommand("Select Id, DOB, Location, Reasons, CancelCol from OtherConcerns Where CancelCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')"))
            {
                SqlCommand CancelOthers = new SqlCommand(resultO, con);
                SqlCommand myColumnO = new SqlCommand(compareO, con);
                SqlCommand checkUsersO = new SqlCommand("select Usersname from Members where Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')", con);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    con.Open();
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        try
                        {
                            if ((CancelOthers.ExecuteNonQuery().ToString().Equals("-1")) && !string.IsNullOrEmpty(CancelOthers.ExecuteScalar().ToString())
                                 && lblCurrentUser.Text.Equals(checkUsersO.ExecuteScalar().ToString()))
                            {
                                lblViewResultForAll.Text = "Your OtherConcern has been cancelled by " + CancelOthers.ExecuteScalar().ToString();
                            }
                            else if ((CancelOthers.ExecuteNonQuery().ToString().Equals("1")))
                            {
                                lblViewResultForAll.Text = "You have no OtherConcern schedules to cancel. Rebook your schedules";
                            }
                            else if ((CancelOthers.ExecuteNonQuery().ToString().Equals("-1") && (string.IsNullOrEmpty(myColumnO.ExecuteScalar().ToString()) && (string.IsNullOrEmpty(CancelOthers.ExecuteScalar().ToString()))
                                && lblCurrentUser.Text.Equals(checkUsersO.ExecuteScalar().ToString()))))
                            {
                                lblViewResultForAll.Text = "Your OtherConcern is still awaiting a feedback, please check again soon ";
                            }
                            else
                                lblViewResultForAll.Text = "Your OtherConcern has been accepted by " + myColumnO.ExecuteScalar().ToString();
                        }
                        catch (NullReferenceException)
                        {
                            lblViewResultForAll.Text = "No data found matching your request. You probably have not schedule any ";
                        }
                        sda.Fill(dt);
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                    }
                }
                con.Close();
            }
        }
    }


    //Method7 to validate data for appointment if empty, exist or not. Retrieve the data and send to Method1
   private bool ValidateAppointment()
    {
        bool app = true;
        string outputApp ="select AppAccept from TraceSchedules where AppAccept is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
        using (SqlConnection myResult = new SqlConnection(aConnectingString))
        {
            SqlCommand checkUsers = new SqlCommand("select Usersname from Members where Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')", myResult);
            SqlCommand fetchView = new SqlCommand(outputApp, myResult);
            myResult.Open();
            if (fetchView.ExecuteNonQuery().ToString().Equals("-1") && (!lblCurrentUser.Text.Equals(checkUsers.ExecuteScalar().ToString())))
            {
                app = false;
                lblViewResultForAll.Text = "You did not schedule any appointments";
            }
            else if (((fetchView.ExecuteNonQuery().ToString().Equals("-1")) || (fetchView.ExecuteScalar().ToString().Equals("NULL")))
                && (lblCurrentUser.Text.Equals(checkUsers.ExecuteScalar().ToString())))
            {
                app = false;
                lblViewResultForAll.Text = "You have no records Scheduled";
            }
            else
                    app = true;
                 lblViewResultForAll.Text = "Your Appointments awaits a response";
        }
        return app;
    }

   //Method8 to validate data for Visitation if empty, exist or not. Retrieve the data and send to Method2
    private bool ValidateVisitations()
    {
          bool visit = true;
        string outputApp ="select AcceptCol from Visitations where AcceptCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
        using (SqlConnection myResult = new SqlConnection(aConnectingString))
        {
            SqlCommand checkUsers = new SqlCommand("select Usersname from Members where Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')", myResult);
            SqlCommand fetchViewV = new SqlCommand(outputApp, myResult);
            myResult.Open();
            if (fetchViewV.ExecuteNonQuery().ToString().Equals("-1") && (!lblCurrentUser.Text.Equals(checkUsers.ExecuteScalar().ToString())))
            {
                visit = false;
                lblViewResultForAll.Text = "You did not schedule any Visitations";
            }
            else if (((fetchViewV.ExecuteNonQuery().ToString().Equals("-1")) || (fetchViewV.ExecuteScalar().ToString().Equals("NULL")))
                && (lblCurrentUser.Text.Equals(checkUsers.ExecuteScalar().ToString())))
            {
                visit = false;
                lblViewResultForAll.Text = "You have no records Scheduled";
            }
            else            
                    visit = true;
                 lblViewResultForAll.Text = "Your Appointments awaits a response";
        }
        return visit;
    }

    //Method9 to validate data for OtherQuery if empty, exist or not. Retrieve the data and send to Method3
    private bool ValidateOtherConcerns()
    {
        bool others = true;
        string outputApp = "select AcceptCol from OtherConcerns where AcceptCol is not null and Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')";
        using (SqlConnection myResult = new SqlConnection(aConnectingString))
        {
            SqlCommand checkUsers = new SqlCommand("select Usersname from Members where Id in (Select Id from Members where Usersname = '" + lblCurrentUser.Text + "')", myResult);
            SqlCommand fetchViewO = new SqlCommand(outputApp, myResult);
            myResult.Open();
            if (fetchViewO.ExecuteNonQuery().ToString().Equals("-1") && (!lblCurrentUser.Text.Equals(checkUsers.ExecuteScalar().ToString())))
            {
                others = false;
                lblViewResultForAll.Text = "You did not schedule any Other Queries";
            }
            else if (((fetchViewO.ExecuteNonQuery().ToString().Equals("-1")) || (fetchViewO.ExecuteScalar().ToString().Equals("NULL")))
                && (lblCurrentUser.Text.Equals(checkUsers.ExecuteScalar().ToString())))
            {
                others = false;
                lblViewResultForAll.Text = "You have no records Scheduled for the Query";
            }
            else
                others = true;
            lblViewResultForAll.Text = "Your  Query awaits a response";
        }
        return others;
    }
    
    //Three different methods to display gridview and user messages
    protected void BtnViewMyAppResp_Click(object sender, EventArgs e)
    {
        retrieveDataApp();    
    }
    protected void btnViewMyVisitResp_Click(object sender, EventArgs e)
    {
        retrieveDataVisit();
    }
    protected void btnViewMyOtherQueryResp_Click(object sender, EventArgs e)
    {
        retrieveDataOthers();
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
    
    //Three Ok button Method to clear the screens respectively
     protected void btnFinishAppView_Click(object sender, EventArgs e)
     {
         GridView1.Visible = false;
         lblViewResultForAll.Text = "";
     }
     protected void btnfinishVisitView_Click(object sender, EventArgs e)
     {
         GridView2.Visible = false;
         lblViewResultForAll.Text = "";
     }
     protected void btnFinishOthersView_Click(object sender, EventArgs e)
     {
         GridView3.Visible = false;
         lblViewResultForAll.Text = "";
     }
}