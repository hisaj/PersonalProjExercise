<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddNewArea.aspx.cs" Inherits="AddNewArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">

    <div>
        <br />
        <br />
        <br />
        <br />
        <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblAddNLoc" runat="server" Text="Add New Location" ForeColor="White"></asp:Label>
        &nbsp; <asp:TextBox ID="txtAddNLoc" runat="server" BorderStyle="Solid" Width="166px"></asp:TextBox>
        &nbsp;&nbsp;
       <!-- <asp:Button ID="btnAddLoc" runat="server" Text="Add" OnClick="btnAddLoc_Click" /> -->
         &nbsp;&nbsp;&nbsp;<asp:Label ID="lblNLErMsg" runat="server" ForeColor="Red"></asp:Label>
        &nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
         <asp:Label ID="lblAddNcity" runat="server" Text="Add New City" ForeColor="White"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtAddNcity" runat="server" BorderStyle="Solid" server="" Width="166px"></asp:TextBox>
        &nbsp;
        &nbsp;<asp:Label ID="lblNciErmsg" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddCity" runat="server" Text="Add" OnClick="btnAddCity_Click" />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a href="Home.aspx" 
            style="font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif; 
             font-style: normal; font-size: small; font-weight: bold; color: gold"> 
             Back to Previous Page  </a>
        <br />
     </div>

</asp:Content>

