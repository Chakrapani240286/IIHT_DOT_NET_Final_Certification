<%@ Page Title="" Language="C#" MasterPageFile="~/Account.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="Project.Manager.Web.forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>PASSWORD RESET</h2>
    <asp:Panel ID="pnlErrorMessage" runat="server" Visible="false">
        <button type="button" class="close" data-dismiss="alert">×</button>
        <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
    </asp:Panel>
    <div class="form-group">
        <div class="email controls">
            <asp:TextBox ID="txtUserName" runat="server" TextMode="Email" placeholder="Registered Email Id" class="form-control input-sm bounceIn animation-delay2"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Registered Email Id" ControlToValidate="txtUserName" ForeColor="Red" ValidationGroup="login"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="submit">
        <asp:Button ID="btnForgotPassword" runat="server" Text="Send Me" ValidationGroup="login" class="btn btn-success btn-sm pull-right" OnClick="btnForgotPassword_Click" />
    </div>
    <div class="forget">
        <a href="/default.aspx?loginrredirectUrl=login-administrator-home&pageId=admin-login.html">
            <span>I Have Password, Login</span>
        </a>
    </div>
</asp:Content>
