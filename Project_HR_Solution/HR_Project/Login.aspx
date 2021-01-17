<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HR_Project.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">
        <div class="col s6">
            <h3>Login </h3>
            <div runat="server" id="alert" visible="false">
                <strong>Error!</strong>

                <p>
                    <asp:Literal runat="server" ID="StatusText" />
                </p>
            </div>
            <div class="input-field">
                <asp:Label ID="Label1" runat="server" Text="Username" AssociatedControlID="username" CssClass="col-form-label col-form-label-sm col-2 text-right"></asp:Label>

                <asp:TextBox ID="username" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="helper-text red-text" Display="Dynamic" ControlToValidate="username" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username required."></asp:RequiredFieldValidator>

            </div>
            <div class="input-field">
                <asp:Label ID="Label2" runat="server" Text="Password" AssociatedControlID="password" CssClass="col-form-label col-form-label-sm col-2 text-right"></asp:Label>

                <asp:TextBox TextMode="Password" ID="password" runat="server" CssClass="form-control form-control-sm"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="helper-text red-text" Display="Dynamic" ControlToValidate="password" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password required."></asp:RequiredFieldValidator>

            </div>
            <div>


                <asp:Button ID="login" runat="server" Text="Login" CssClass="btn red" OnClick="login_Click" />

            </div>
            <div style="margin-top:10px;">
                If you haven't signed up yet, <a href="/Register.aspx">Register</a> here.
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
