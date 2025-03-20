<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SkyGardens.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="constrained fluid-flex">
        <div style="grid-column: 1 / 3">
            <h2>Welcome</h2>
            <p>
                This console allows you to manage stock keeping units of flowers, create orders, monitor stock levels and see up-to-date analytics. Using the console requires an account in the SkyGardens Database. 
                <br />
                <br />
                <div style="font-size: 0.8em">
                    Developed by Christian Yalamov<br />
                    Undergraduate Student <span class="semi-transparent">at the</span> Faculty of Business and Law <span class="semi-transparent">(Manchester Metropolitan University)</span>
                </div>
            </p>
        </div>

        <div>
            <h3>Limited access</h3>
            <p>
                The management console requires you to have an account in the database.
                <br /><br /><asp:button runat="server" Text="Log in" ID="btn_logIn" OnClick="btn_logIn_Click" />
            </p>
        </div>
    </div>
</asp:Content>
