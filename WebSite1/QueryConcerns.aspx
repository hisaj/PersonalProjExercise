<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="QueryConcerns.aspx.cs" Inherits="QueryConcerns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div class="queryLgout">
          &nbsp;&nbsp;&nbsp;
          Welcome &nbsp;&nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" Width="69px" />
      </div>
    <div id="BKotherSchedule">
        <h2> Other Concerns</h2>
        <asp:Panel ID="Panel3" runat="server">
             <br />
        <asp:Button ID="btnOthersGetID" runat="server" Text="Click To Get Your ID" OnClick="btnOthersGetID_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="lblshowOthersID" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblOthersDOB" runat="server" Text="Date of Birth"></asp:Label>
            &nbsp;<asp:TextBox ID="txtOtherDOB" runat="server" ToolTip="Entry format: 1Jan2000"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblOtherReason" runat="server" Text="Reasons"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtOthersPurpose" runat="server" Height="49px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblOtherSchdLoc" runat="server" Text="Location"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtOtherSchdlLoc" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblotherSchdCity" runat="server" Text="City"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtOtherScdlCity" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblOtherMedCad" runat="server" Text="Medical Card:"></asp:Label>
            &nbsp;&nbsp;&nbsp; Yes<asp:CheckBox ID="CheckBoxOtherYes" runat="server" />
            &nbsp;No
            <asp:CheckBox ID="CheckBoxOtherNo" runat="server" />
             <br />
             <br />
             <asp:Label ID="lblQueryFErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnQuerySubmit" runat="server" Text="Submit" OnClick="btnQuerySubmit_Click" />
             &nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancelQuery" runat="server" Text="Cancel" OnClick="btnCancelQuery_Click"  />
            <br />
            <br />
        </asp:Panel>
    </div>
      
     <br />
    <br />
    <br />
    </asp:Content>

