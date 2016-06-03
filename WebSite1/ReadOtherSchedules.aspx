<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReadOtherSchedules.aspx.cs" Inherits="ReadOtherSchedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div id="otherlgout">
          Welcome &nbsp;&nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
      </div>  
      <div id="otherSheet">
        <h3> Other Schedules Sheet </h3>

           &nbsp;
         <asp:DropDownList ID="ddlQueryPickUp" runat="server" Height="23px" Width="155px"  >
         </asp:DropDownList>
        &nbsp; <asp:Button ID="btnQuerySheet" runat="server" Text="View Record"   />
         <br />
         <br />
        <asp:Label ID="lblOtherSchdID" runat="server" Text="Identity No"></asp:Label>&nbsp; &nbsp;<asp:Label ID="lblidOthers" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <!-- <asp:Label ID="lblReadOtherName" runat="server" Text="Full Name"></asp:Label> &nbsp; &nbsp;<asp:Label ID="lblOtherNameResult" runat="server" Width="200px"></asp:Label>
        <br />
        <br />-->
          <asp:Label ID="lblOtherdob" runat="server" Text="DOB"></asp:Label>&nbsp; &nbsp;<asp:Label ID="lblOtherdobResult" runat="server" Text=""></asp:Label>
        <br />
        <br />
         <asp:Label ID="lblOthersWhy" runat="server" Text="Reasons"> </asp:Label>&nbsp; &nbsp;<asp:TextBox ID="txtOChoiceWhy" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
            <br />
            <asp:Label ID="lblOtherSchdLoc" runat="server" Text="Location"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtOtherSchdlLoc" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblotherSchdCity" runat="server" Text="City"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtOtherScdlCity" runat="server"></asp:TextBox>
            <br />
            <br />
           <asp:Label ID="lblOtherMedCard" runat="server" Text="Medical Card"> </asp:Label>&nbsp; &nbsp;<asp:Label ID="lblOtherChoiceMedCd" runat="server" Text=""></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAcceptinOtherFella" runat="server" ToolTip="Your Name"></asp:TextBox><asp:Button ID="btnAcceptOther" runat="server" Text="Accept " OnClick="btnAcceptOther_Click" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtCancelinOtherfella" runat="server" TextMode="MultiLine" ToolTip="Your Name and Cancel Reasons"></asp:TextBox><asp:Button ID="btnCancelOther" runat="server" Text="Cancel" OnClick="btnCancelOther_Click" />

          <br />
          <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnFinishOthersReading" runat="server" Text="Am Finish" OnClick="btnFinishOthersReading_Click"  />
          <br />
         <br />

    </div>
     
</asp:Content>

