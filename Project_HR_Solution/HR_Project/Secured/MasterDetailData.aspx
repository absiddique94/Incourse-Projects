<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MasterDetailData.aspx.cs" Inherits="HR_Project.Secured.MasterDetailData" %>

<%@ Register Src="~/Secured/MasterDetailDataUC.ascx" TagPrefix="uc1" TagName="MasterDetailDataUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <uc1:MasterDetailDataUC runat="server" ID="MasterDetailDataUC" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
