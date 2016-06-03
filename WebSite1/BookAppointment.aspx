<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookAppointment.aspx.cs" Inherits="BookAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="Lgout">
          Welcome &nbsp;&nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Width="69px" />
      </div> 
    
     <div class="App">
    <h2>&nbsp;Schedule Appointment </h2>
    <asp:Panel ID="Panel1" runat="server">
         <br />
        <asp:Button ID="btnGetAppID" runat="server" Text="Click To Get Your ID" OnClick="btnGetAppID_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="lblShowMemAppSchdID" runat="server" Text=""></asp:Label>
    <br />
         <br />
         <asp:CheckBox ID="CheckBoxHospital" runat="server" />
         &nbsp;Hospital
         <asp:CheckBox ID="CheckBoxGP" runat="server" />
         &nbsp; GP
         <br />
         <br />
    <asp:Label ID="lblSchdSurName" runat="server" Text="Last Name"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtSchdSurName" runat="server"></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblSchedlfirName" runat="server" Text="First Name"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;<asp:TextBox ID="txtScFirName" runat="server"></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblSchDOB" runat="server" Text="Date Of Birth"></asp:Label>
         &nbsp; &nbsp <asp:TextBox ID="txtSchdDOB" runat="server" ToolTip="Entry format; 1Jan2000"></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblShdReason" runat="server" Text="Reason"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtSchdReason" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
         <br />
   <asp:Label ID="lblSchdTime" runat="server" Text="Select Time"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlSchdTime" runat="server" Height="18px" Width="88px">
            <asp:ListItem>Pick Time</asp:ListItem>
            <asp:ListItem>09:00</asp:ListItem>
            <asp:ListItem>10:00</asp:ListItem>
            <asp:ListItem>11:00</asp:ListItem>
            <asp:ListItem>12:00</asp:ListItem>
            <asp:ListItem>13:00</asp:ListItem>
            <asp:ListItem>14:00</asp:ListItem>
            <asp:ListItem>15:00</asp:ListItem>
            <asp:ListItem>16:00</asp:ListItem>
            <asp:ListItem>17:00</asp:ListItem>
            <asp:ListItem>18:00</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblSchdLoc" runat="server" Text="Location"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtSchdLoc" runat="server"></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblScdCity" runat="server" Text=" City"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtSchdCity" runat="server"></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblSchdDay" runat="server" Text="Day"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlSchdDay" runat="server" Height="16px" Width="116px">
        <asp:ListItem>Select Option</asp:ListItem>
        <asp:ListItem>Sunday</asp:ListItem>
        <asp:ListItem>Monday</asp:ListItem>
        <asp:ListItem>Tuesday</asp:ListItem>
        <asp:ListItem>Wednesday</asp:ListItem>
        <asp:ListItem>Thursday</asp:ListItem>
        <asp:ListItem>Friday</asp:ListItem>
        <asp:ListItem>Saturday</asp:ListItem>
    </asp:DropDownList>
    <br />
         <br />
        &nbsp;<asp:Label ID="lblSchdMedCard" runat="server" Text="Medical Card"></asp:Label>
        &nbsp;<br />
    Yes<asp:CheckBox ID="ChkBoxMedYes" runat="server" /> &nbsp;No <asp:CheckBox ID="ChkBoxMedNo" runat="server" />
         <br />
         <br />
         <asp:Label ID="lblAppValidation" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
    <br />
         
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSchdOk" runat="server" Text="Submit" OnClick="btnSchdOk_Click" /> &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelApp" runat="server" Text="Cancel" OnClick="btnCanelApp_Click" />
        <br />
         <br />
    </asp:Panel>
    <br /></div>
     
     <br />
    <br />
    <br />
</asp:Content>

