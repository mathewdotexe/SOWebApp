<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignUpControls.ascx.cs" Inherits="Project5.SignUpController" %>

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
<asp:Image ID="verifyImage" runat="server" style="margin-left: 107px" />
<br /><br />
<asp:Label ID="verifyTextLabel" runat="server" Text="Verify Text Above:" style="margin-left: 8px"></asp:Label>
<asp:TextBox ID="verifyInput" runat="server" style="margin-left: 37px"></asp:TextBox>
<br /><br />
<asp:Button ID="registerButton" runat="server" Text="Register" Width="100px" style="margin-left: 114px" OnClick="registerButton_Click" Height="26px" />
<br /><br />
<asp:Label ID="loginLabel" runat="server" style="margin-left: 55px" Text=""></asp:Label>
<br /><br />
<asp:Label ID="returnLabel" runat="server" style="margin-left: 10px" Text=""></asp:Label>