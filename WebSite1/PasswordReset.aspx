<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PasswordReset.aspx.cs" Inherits="PasswordReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div id ="MemLogin">
    <h2> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Reset My Password </h2>
    <asp:Panel ID="Panel1" runat="server" Height="328px" Width="467px" style="margin-right: 3px">
        <br />
         <br />
&nbsp;<asp:Label ID="lblUsersName" runat="server" Text="Usersname"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtMemUsernameR" runat="server" BorderStyle="Solid" Width="166px"></asp:TextBox>
            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblResetName" runat="server"  ForeColor="Red"></asp:Label>
            <br />
            <br />
&nbsp;<asp:Label ID="lblNewPasswd" runat="server" Text="New Password"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNewPswdReset" runat="server" BorderStyle="Solid" Width="166px" TextMode="Password"></asp:TextBox>
&nbsp;<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblNewPswdReset" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <br />
        &nbsp;<asp:Label ID="lblConfirmPswdReset" runat="server" Text="Confirm Password"></asp:Label>
        &nbsp;&nbsp;
            <asp:TextBox ID="txtConfNewPswd" runat="server" BorderStyle="Solid" Width="166px" TextMode="Password"></asp:TextBox>
           <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;
           <asp:CompareValidator ID="CompareValidatorPswd" runat="server" ErrorMessage="Password do not match" 
            ControlToCompare="txtNewPswdReset" ControlToValidate="txtConfNewPswd" ForeColor="Red"></asp:CompareValidator>
            <br />
            <asp:Label ID="lblResetPwsd" runat="server" ForeColor="Red" Visible="False">Password Succesfully changed</asp:Label>
            <br />
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp
        ;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnResetPassword" runat="server" Text="Save Changes" OnClick="btnResetPassword_Click"  />
        <h4>   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
          <a href="login.aspx"> <span> Back to Login</span></a></h4>
    </asp:Panel>
    </div>
</asp:Content>

