<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <br />
    <div id="about"> 
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" BorderStyle="None" Font-Size="X-Large">
        <br />
        <span class="about" > This is a website build to enable anyone book an express appointment.<br /> 
            Wherever you are, you can quickly schedule an appointments to visit
        your nearest Hospital or Healthcare professional for that particular moment or time, regardless of your location.<br /> 
         You can also schedule to be visited by a doctor or a Health professional wherever you are.<br />
         All you need is your ID and your location ID for those who are already a signed-up members.</span> 
        
        <h6> Not a member yet. &nbsp;  <a href="Registration.aspx"> <span style="color:white">Become a Member </span></a></h6>
</asp:Panel>
    </div>
</asp:Content>

