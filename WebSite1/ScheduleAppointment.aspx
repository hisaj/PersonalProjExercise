<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ScheduleAppointment.aspx.cs" Inherits="ScheduleAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">

    <div id ="memMainPg"> 
    Welcome &nbsp;&nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSignOut" runat="server" Text="Logout" OnClick="btnSignOut_Click"  />
   </div>

     <div id="ScheduleOption">
          <h5> Choose a Button Option </h5>
       
            &nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSchApp" runat="server" Text="Schedule An Appointment " BackColor="seagreen" OnClick="btnSchApp_Click" Font-Names="Elephant" Font-Size="X-Large" Height="82px" Width="350px"  />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSchVisit" runat="server" Text="Schedule A Visitation " BackColor="mintcream" OnClick="btnSchVisit_Click" Font-Names="Elephant" Font-Size="X-Large" Height="82px" Width="350px"  />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnSchOthers" runat="server" Text="Schedule Other Enquiries" BackColor="skyblue" OnClick="btnSchOthers_Click" Font-Names="Elephant" Font-Size="X-Large" Height="82px" Width="350px" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCheckReplies" runat="server" Text="Check Responses Status" OnClick="btnCheckReplies_Click" Font-Names="Bodoni MT Black" Font-Size="XX-Large" Height="82px" />&nbsp;&nbsp;&nbsp;
            <br />
            <br />
       &nbsp;&nbsp;&nbsp;
    </div> 

</asp:Content>

