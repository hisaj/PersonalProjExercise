<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div id="MemLogin">
         <h2>  Members Login </h2>     
        <asp:Panel ID="Panel1" runat="server" Height="303px" Width="406px">
            <br />
&nbsp;<asp:Label ID="lblUsersName" runat="server" Text="Usersname"></asp:Label>
&nbsp;
            <asp:TextBox ID="txtMemLogin" runat="server" BorderStyle="Solid" Width="166px"></asp:TextBox>
            <asp:Label ID="lblLoginName" runat="server"  ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblMemPswd" runat="server" Text="Password"></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtMemLoginPswd" runat="server" BorderStyle="Solid" Width="182px" TextMode="Password"></asp:TextBox>
            <asp:Label ID="lblLoginPsw" runat="server"  ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <h4> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               &nbsp;&nbsp; <a href="Registration.aspx">Not a member yet </a></h4>
            <h4> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             &nbsp;<a href="PasswordReset.aspx">Forgot my password</a></h4>
        </asp:Panel>
           </div>
                
    </asp:Content>