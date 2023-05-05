<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminControls.ascx.cs" Inherits="Project5.AdminController" %>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="userNameLabel" runat="server" Text="User Name:"></asp:Label>
<asp:TextBox ID="userNameInput" runat="server" style="margin-left: 32px"></asp:TextBox>
<br /><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="passwordLabel" runat="server" Text="Password:"></asp:Label>
<asp:TextBox ID="passwordInput" runat="server" TextMode="Password" style="margin-left: 34px"></asp:TextBox>
<br />
<asp:Label ID="confirmPassLabel" runat="server" Text="Confirm Password:"></asp:Label>
<asp:TextBox ID="confirmPassInput" runat="server" TextMode="Password" style="margin-left: 35px"></asp:TextBox>
<br /><br />
<asp:Button ID="registerButton" runat="server" Text="Add Staff" Width="100px" style="margin-left: 114px" OnClick="registerButton_Click" Height="26px" />
<br /><br />
<asp:Label ID="returnLabel" runat="server" style="margin-left: 10px" Text=""></asp:Label>