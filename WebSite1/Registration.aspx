<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>


<asp:Content ID="Conten1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentBody" Runat="Server">
    <div id="RegstnDiv">
       <h2> &nbsp;&nbsp; New Member Register Here</h2>
        <asp:Panel ID="Panel1" runat="server" Height="638px" Width="401px">
            <br />
            &nbsp;<asp:Label ID="lblfirstname" runat="server" Text="Firstname"></asp:Label>
            &nbsp; &nbsp;&nbsp;<asp:TextBox ID="txtNewMemfirstname" runat="server" BorderStyle="Groove"></asp:TextBox>
            <asp:Label ID="lblRname" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lbllastname" runat="server" Text="Lastname"></asp:Label>
            &nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtNewMemlastname" runat="server" BorderStyle="Groove"></asp:TextBox>
            <asp:Label ID="lblRsurname" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblNewUsername" runat="server" Text="Usersname"></asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="txtNewMemUsersname" runat="server" BorderStyle="Groove"></asp:TextBox>
            <asp:Label ID="lblRusername" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
&nbsp;<asp:Label ID="lblNewMenPswd" runat="server" Text="Passwords"></asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="txtNewMemPswd" runat="server" BorderStyle="Groove" TextMode="Password"></asp:TextBox>
            <asp:Label ID="lblRpassword" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblNMemConfPswd" runat="server" Text="Confirm Pw"></asp:Label>
            &nbsp;<asp:TextBox ID="txtNMemConfPswd" runat="server" BorderStyle="Groove" TextMode="Password"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidatorPswd" runat="server" ControlToCompare="txtNewMemPswd" ControlToValidate="txtNMemConfPswd" ErrorMessage="Password do not match" ForeColor="Red"></asp:CompareValidator>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblemail" runat="server" Text="E-mail"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmailAdd" runat="server" BorderStyle="Groove" TextMode="Email" Width="157px"></asp:TextBox>
            <asp:Label ID="lblRemail" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
             &nbsp;Male<asp:CheckBox ID="CheckBoxMale" runat="server" />
            &nbsp; Female <asp:CheckBox ID="CheckBoxFemale" runat="server" /> <br />
            <asp:Label ID="lblRcheckboxes" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            &nbsp;<asp:Label ID="lblAddress" runat="server" Text="Residence"></asp:Label>
            &nbsp; &nbsp;<asp:TextBox ID="txtAddress" runat="server" BorderStyle="Groove" Height="39px" TextMode="MultiLine"></asp:TextBox>
            <asp:Label ID="lblRaddress" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtLocation" runat="server" BorderStyle="Groove"></asp:TextBox>
            <asp:Label ID="lblRloc" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCity" runat="server" BorderStyle="Groove"></asp:TextBox>
            <asp:Label ID="lblRcit" runat="server" Text="" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <!--&nbsp;<asp:Label ID="lblPhone" runat="server" Text="Phone Nos"></asp:Label>
            &nbsp;&nbsp;<asp:TextBox ID="txtPhone" runat="server" BorderStyle="Groove"></asp:TextBox>
            <br />
            <br /> -->
            &nbsp;<asp:Label ID="lblHealthProfession" runat="server" Text="Qualified Health Professional"></asp:Label>
            &nbsp;&nbsp;&nbsp;<br /> &nbsp;Yes<asp:CheckBox ID="ChkBProYes" runat="server" />
            <!-- &nbsp; No<asp:CheckBox ID="ChkBProNo" runat="server" /> -->
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnOkRegistration" runat="server" Text="Register" OnClick="btnOkRegistration_Click" />
        <br />

        </asp:Panel>
         </div>
    <br />
   </asp:Content>
