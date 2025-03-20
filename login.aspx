<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SkyGardens.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="fluid-flex constrained" style="margin-top: 40px;">
        <div>
            <h2 style="margin-top: 0">Authenticate</h2>
            <p>Please enter your credentials to access the system (DB user: admin/skygardens).</p>
        </div>
        <div>
            <asp:TextBox ID="txt_username" CssClass="username_input" runat="server" Visible="True" placeholder="Username"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validator" ID="UsernameRequiredValidator" runat="server" ErrorMessage="Username is required" ControlToValidate="txt_username">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:TextBox ID="txt_password" CssClass="password_input" runat="server" Visible="True" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="validator" ID="PasswordRequiredValidator" runat="server" ErrorMessage="Password is required" ControlToValidate="txt_password">*</asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Button ID="btn_login" runat="server" Text="Log in" OnClick="btn_login_Click" />
            <br />
            <br />
            <asp:CustomValidator ID="CredentialsValidator" CssClass="validator-big" runat="server" ErrorMessage="The username and password you have entered have not been recognised. Please try again." Visible="false"></asp:CustomValidator>


        </div>
    </div>
</asp:Content>
