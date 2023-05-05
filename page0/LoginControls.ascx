<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControls.ascx.cs" Inherits="Project5.LoginController" %>

<asp:Label ID="userNameLabel" runat="server" Text="User Name:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="userNameInput" runat="server" style="margin-left: 2px"></asp:TextBox>
<br /><br />
&nbsp;
<asp:Label ID="passwordLabel" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="passwordInput" TextMode="Password" runat="server"></asp:TextBox>
<br /><br />
<asp:Button ID="loginButton" runat="server" style="margin-left: 98px" Text="Login" Width="80px" OnClick="loginButton_Click" Height="26px" />
<br /><br />
<asp:Label ID="registerLabel" runat="server" style="margin-left: 30px" Text=""></asp:Label>
<br /><br />
<asp:Label ID="responseLabel" runat="server" Text=""></asp:Label>