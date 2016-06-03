<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReplyBoard.aspx.cs" Inherits="ReplyBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
   
    <div id ="replyScreenSession"> 
    Welcome &nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text=""></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click"  />
   </div>
    
    <!-- <div class="checkReply"> 
    <asp:Label ID="lblAppointmentReply" runat="server" Text="result here"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblAwaitingResponse" runat="server" Text="result Here"></asp:Label>
    <br />
    <br />
     <asp:Label ID="lblRebookAppointment" runat="server" Text="Result Here"></asp:Label>
    </div> -->

    <div id="ProfAppViews">
          <h5> Official Professional Uses </h5>
        <asp:Panel ID="Panel1" runat="server">
            <asp:Button ID="btnReadApptmt" runat="server" Text="Read Appointment Schedules" BackColor="#E9C843" OnClick="btnReadApptmt_Click" Font-Names="Copperplate Gothic Bold" Font-Size="Large" Height="82px" Width="350px" />
            <br />
            <br />
            <asp:Button ID="btnReadVisit" runat="server" Text="Read Visitation Schedules" BackColor="#2DD9BF" OnClick="btnReadVisit_Click" Font-Names="Copperplate Gothic Bold" Font-Size="Large" Height="82px" Width="350px" />
            <br />
            <br />
            <asp:Button ID="btnReadOthers" runat="server" Text="Read Other Schedules" BackColor="#F9395B" OnClick="btnReadOthers_Click" Font-Names="Copperplate Gothic Bold" Font-Size="Large" Height="81px" Width="350px" />
            <br />
            <br />
        </asp:Panel>
    </div>
    
</asp:Content>

