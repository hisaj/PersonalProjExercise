<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReadVisitationSchedules.aspx.cs" Inherits="ReadVisitationSchedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
   
    <div id="rdapplout">
          Welcome &nbsp;&nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
      </div> 
     <div id="visitatnSheet">
        <h3> Visitation Sheet </h3>

         &nbsp;
         <asp:DropDownList ID="ddlVisitationPickUp" runat="server" Height="23px" Width="155px"  >
         </asp:DropDownList>
        &nbsp; <asp:Button ID="btnViewVisitSheet" runat="server" Text="View Record" OnClick="btnViewVisitSheet_Click" />
         <br />
         <br />
         <asp:Label ID="lblVSID" runat="server" Text="ID"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblVSIDResult" runat="server" Width="200px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblReadVistName" runat="server" Text="Full Name"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblVNameResult" runat="server" Width="200px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblVistChoice" runat="server" Text="Choice type"> </asp:Label>
        &nbsp; &nbsp;<asp:Label ID="lblVChoiceResult" runat="server" Text=""> </asp:Label>&nbsp; &nbsp;<asp:DropDownList ID="ddlAssignChoice" runat="server" Height="19px" Width="195px"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblVistDay" runat="server" Text="Day"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblVChoiceDay" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblVistdob" runat="server" Text="DOB"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblVChoiceDOB" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblVistLoc" runat="server" Text="Location"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblVChoiceLoc" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblVistCity" runat="server" Text="City"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblVChoiceCity" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblVTime" runat="server" Text="Time"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblVDispTime" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblVistFone" runat="server" Text="Phone No"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblVChoicePhone" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblVistMedCard" runat="server" Text="Medical Card"></asp:Label>&nbsp; &nbsp;<asp:Label ID="lblVChoiceMedCd" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblVistWhy" runat="server" Text="Reasons"> </asp:Label>&nbsp; &nbsp;<asp:TextBox ID="txtVChoiceWhy" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAcceptinVistFella" runat="server" ToolTip="your name"></asp:TextBox><asp:Button ID="btnAcceptVist" runat="server" Text="Accept Visitation" OnClick="btnAcceptVist_Click" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCancelinVistfella" runat="server" TextMode="MultiLine" ToolTip="your name and cancel reason"></asp:TextBox><asp:Button ID="btnCancelVist" runat="server" Text="Cancel Visitation" OnClick="btnCancelVist_Click" />

         <br />
         <br />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnFinishVisitReading" runat="server" Text="Am Finish" OnClick="btnFinishVisitReading_Click"  />
         <br />

    </div>
    
</asp:Content>

