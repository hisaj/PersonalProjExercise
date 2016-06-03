<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookVisitation.aspx.cs" Inherits="BookVisitation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
   
     <div class="VistLgout">
          Welcome &nbsp;&nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Width="69px" />
      </div> 
    
     <br /><div class="BKvisit">
    <h2>Schedule Visit </h2>
    <asp:Panel ID="Panel2" runat="server">
        <br />
        <asp:Button ID="btnGetVisitID" runat="server" Text="Click To Get Your ID" OnClick="btnGetVisitID_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="lblShowVisitMemID" runat="server" Text=""></asp:Label>
    <br />
         <br />
      
    <asp:Label ID="lblVisitSurName" runat="server" Text="Last Name"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="txtVisitSurName" runat="server"></asp:TextBox>
    <br />
         <br />
     <asp:Label ID="lblVisitFirstName" runat="server" Text="First Name"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtVisitFirName" runat="server" ></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblVisitDOB" runat="server" Text="Date Of Birth"></asp:Label> &nbsp; &nbsp <asp:TextBox ID="txtVisitDOB" runat="server" ToolTip="Entry format: 1Jan2000"></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblVisitLoc" runat="server" Text="Location"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtVisitLoc" runat="server"></asp:TextBox>
    <br />
     <br />
    <asp:Label ID="lblVisitCity" runat="server" Text="City"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtVisitCity" runat="server"></asp:TextBox>
    <br />
         <br />
   <asp:Label ID="lblVisitTime" runat="server" Text="Select Time"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlVisitTime" runat="server" Height="16px" Width="87px">
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
    <asp:Label ID="lblVisitReason" runat="server" Text="Reason"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtVisitReason" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblVisitPhone" runat="server" Text=" Phone Number"></asp:Label> &nbsp; <asp:TextBox ID="txtVisitPhone" runat="server"></asp:TextBox>
    <br />
         <br />
    <asp:Label ID="lblVisitDay" runat="server" Text="Day"></asp:Label> &nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlVisitDay" runat="server" Height="16px" Width="116px">
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
        &nbsp;
        <asp:Label ID="lblVisitMedCard" runat="server" Text="Medical Card"></asp:Label>
        &nbsp;&nbsp;
    Yes<asp:CheckBox ID="CheckBoxMedVisitYes" runat="server" /> &nbsp;No <asp:CheckBox ID="CheckBoxMedVisitNo" runat="server" />
        <br />
        <br />
        <asp:Label ID="lblVistErr" runat="server" ForeColor="Red"></asp:Label>
        <br />      
        <br />   
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSubmitVisit" runat="server" Text="Submit" OnClick="btnSubmitVisit_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelVisit" runat="server" Text="Cancel" OnClick="btnCancelVisit_Click" />
        <br />
         <br />
    </asp:Panel>
</div>
    
     <br />
    <br />
    <br />
    <br />
</asp:Content>

