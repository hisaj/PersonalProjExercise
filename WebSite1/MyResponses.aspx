<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyResponses.aspx.cs" Inherits="MyResponses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
     <div id ="memMainPg"> 
    Welcome &nbsp;&nbsp; 
          <asp:Label ID="lblCurrentUser" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSignOut" runat="server" Text="Logout" OnClick="btnSignOut_Click"  />
   </div>
    

    <div class="AllGrd"> <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="BtnViewMyAppResp" runat="server" Text="View Appointments Response" OnClick="BtnViewMyAppResp_Click" Font-Names="Bell MT" Font-Size="X-Large" BackColor="#006600" />
         &nbsp;&nbsp; <asp:Button ID="btnFinishAppView" runat="server" Text="OK" OnClick="btnFinishAppView_Click" Font-Names="Bell MT" Font-Size="Larger" BackColor="#006600" />
    <br />
    <br />    
    <div id ="GrdV1"> 
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="347px" >
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />       
    </asp:GridView>
        <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
    <br />  
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnViewMyVisitResp" runat="server" Text="View Visitation Response" OnClick="btnViewMyVisitResp_Click" Font-Names="Berlin Sans FB" Font-Size="X-Large" BackColor="#FFFFCC" />
          &nbsp;&nbsp; <asp:Button ID="btnfinishVisitView" runat="server" Text="OK" OnClick="btnfinishVisitView_Click" Font-Names="Berlin Sans FB" Font-Size="Larger" BackColor="#FFFFCC" />
    <br />
    <br />
     <div id ="GrdV2">
        
    <asp:GridView ID="GridView2" runat="server" CellPadding="4" GridLines="None" Width="347px" ForeColor="#333333" >
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />       
    </asp:GridView>
         <br />
    <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
          </div>
    <br /> 
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="btnViewMyOtherQueryResp" runat="server" Text="View OtherEnquiries Response" OnClick="btnViewMyOtherQueryResp_Click" Font-Names="Baskerville Old Face" Font-Size="X-Large" BackColor="#33CCFF" />
       &nbsp;&nbsp; <asp:Button ID="btnFinishOthersView" runat="server" Text="OK" OnClick="btnFinishOthersView_Click" Font-Names="Baskerville Old Face" Font-Size="Larger" BackColor="#33CCFF" />
         <br />
         <br />
    <div id ="GrdV3"> 
       
     <asp:GridView ID="GridView3" runat="server" CellPadding="3" Width="347px" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2" HorizontalAlign="Right" >
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />       
    </asp:GridView>
        <br />
        <br />
    <asp:SqlDataSource ID="SqlDataSource3" runat="server"></asp:SqlDataSource>
        </div>
        <br />
        <br />
        <div class="lblResultView">     
     <asp:Label ID="lblViewResultForAll" runat="server" ForeColor="White" Font-Bold="True" Font-Size="Large" Font-Names="Bookman Old Style" Width="500px"></asp:Label>
    <br /></div>
        <br />
        <br />
    </div>
     <br />
     <br />
    
</asp:Content>

