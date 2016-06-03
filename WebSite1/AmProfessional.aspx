<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AmProfessional.aspx.cs" Inherits="AmProfessional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
     <div id="confirmProfsn"> 
    <h2> &nbsp;&nbsp; Confirm your profession </h2>
    <asp:Panel ID="Panel1" runat="server" Height="322px" Width="380px">
        
        &nbsp;<br />
        <asp:Label ID="Label1" runat="server" Text="Confrim Email again"></asp:Label>
        &nbsp;<asp:TextBox ID="txtConfirmProEmail" runat="server" BorderStyle="Solid" Width="166px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblProfession" runat="server" Text="Profession"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtProfession" runat="server" BorderStyle="Solid" Width="166px"></asp:TextBox>
        <br />
        <br />
        &nbsp;<asp:Label ID="lblcompany" runat="server" Text="Work Address"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txtWorkAddress" runat="server" BorderStyle="Solid" Width="182px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
&nbsp;<asp:Label ID="lblDuration" runat="server" Text="Duration of Working"></asp:Label>
&nbsp;<asp:TextBox ID="txtDuration" runat="server" BorderStyle="Solid" Width="78px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblThankYou" runat="server" Text="Click Ok for your ID"></asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="btnOkProID" runat="server" Text="OK" OnClick="btnOkProID_Click" />
        <br />
        <br />
        <asp:Label ID="lblProfID" runat="server" Text="Your ID is "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblShowProfID" runat="server" Text=""></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnProRegister" runat="server" Text="Submit" OnClick="btnProRegister_Click" />

        <br />
        

        </asp:Panel>
         </div>
    </asp:Content>
