<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReadAppointmentSchedules.aspx.cs" Inherits="ReadAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div id="rdapplout">
          Welcome &nbsp;&nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click"  />
      </div> 
    
     <div id ="apptmtSheet">
        <h3> Appointment Sheet </h3>

          &nbsp;
         <asp:DropDownList ID="ddlAppointmentPickUp" runat="server" Height="23px" Width="155px"  >
         </asp:DropDownList>
        &nbsp; <asp:Button ID="btnViewAppointSheet" runat="server" Text="View Record" OnClick="btnViewAppointSheet_Click"  />
         <br />
         <br />
         <asp:Label ID="lblAPPID" runat="server" Text="ID"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblRAIDResult" runat="server" Width="200px"></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblAppHos" runat="server" Text="Hospital"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblAppHosResult" runat="server" Width="200px"></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblAppGP" runat="server" Text="GP"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblAppGPResult" runat="server" Width="200px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblReadAppName" runat="server" Text="Full Name"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblANameResult" runat="server" Width="200px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblApptmtChoice" runat="server" Text="Choice type"> </asp:Label>
        &nbsp; &nbsp;<asp:Label ID="lblAChoiceResult" runat="server" Text=""> </asp:Label>&nbsp; &nbsp;<asp:DropDownList ID="ddlAssignChoice" runat="server" Height="19px" Width="195px"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblApptmtDay" runat="server" Text="Day"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblAChoiceDay" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblApptmtdob" runat="server" Text="DOB"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblAChoiceDOB" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblApptmtLoc" runat="server" Text="Location"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblAChoiceLoc" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblApptmtCity" runat="server" Text="City"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblAChoiceCity" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblApptmtFone" runat="server" Text="Phone No"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblAChoicePhone" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblApptmtMedCard" runat="server" Text="Medical Card"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblAChoiceMedCd" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblApptmtWhy" runat="server" Text="Reasons"> </asp:Label>&nbsp; &nbsp;<asp:TextBox ID="txtAChoiceWhy" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAcceptinFella" runat="server" ToolTip="Your Name"></asp:TextBox><asp:Button ID="btnAcceptApptmt" runat="server" Text="Accept Appointment" OnClick="btnAcceptApptmt_Click" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCancelinfella" runat="server" TextMode="MultiLine" ToolTip="Your Name and Cancel Reasons"></asp:TextBox><asp:Button ID="btnCancelApptmt" runat="server" Text="Cancel Appointment" OnClick="btnCancelApptmt_Click" />

         <br />
         <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnFinishAppReading" runat="server" Text="Am Finish" OnClick="btnFinishAppReading_Click" />
         <br />

    </div>

    
</asp:Content>

