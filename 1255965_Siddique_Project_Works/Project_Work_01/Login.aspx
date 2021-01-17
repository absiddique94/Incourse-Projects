<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Project_Work_01.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <div class="row">
        <div class="col">
            <div class="form-group row">
                
                <div class="col-4 offset-2">
                    <h3>Sign in</h3>
                </div>
            </div>
            <div class="form-group row" id="msg" runat="server" visible="false">
                
                <div class="col">
                    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="Label1" CssClass="col-form-label col-2 text-right" AssociatedControlID="username" runat="server" Text="Username"></asp:Label>
                <div class="col-4">
                    <asp:TextBox CssClass="form-control form-control-sm" ID="username" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <asp:Label ID="Label2" CssClass="col-form-label col-2 text-right" AssociatedControlID="password" runat="server" Text="Password"></asp:Label>
                <div class="col-4">
                    <asp:TextBox TextMode="Password" CssClass="form-control form-control-sm" ID="password" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-4 offset-2">
                    <asp:Button CssClass="btn btn-primary btn-sm" ID="btnSignin" runat="server" Text="Sign in" OnClick="btnSignin_Click"  />
                </div>
            </div>
           
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
