<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    
    <div class="hompg">

        <h6> If your present Location or the City is not on the list.<br />
             You can add by clicking the botton below </h6>
      <br/>  
    <asp:Label ID="lblHomLocation" runat="server" Text="Location" ForeColor="White"></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlLocation" runat="server" Height="21px" Width="154px" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged">
            <asp:ListItem>Select your Location</asp:ListItem>
        </asp:DropDownList>
         &nbsp;&nbsp; <asp:Button ID="btnLocGo" runat="server" Text="Go" OnClick="btnLocGo_Click"  /> &nbsp;&nbsp;
         &nbsp;  <asp:Label ID="lblCity" runat="server" Text="City" ForeColor="White"></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlCity" runat="server" Height="21px" Width="154px" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged">
            <asp:ListItem>Select your City</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp; &nbsp;
       <asp:Button ID="btnContinue" runat="server" Text="Continue" OnClick="btnContinue_Click" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFillNewArea" runat="server" Text="Add New Area" OnClick="btnFillNewArea_Click" />
        <br />
        <br />
        <br />
    </div>
   </asp:Content>
