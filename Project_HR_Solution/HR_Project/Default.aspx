<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HR_Project.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="row">

        <h3>Pages/Files- Requirement List</h3>
        <table>
            <thead>
                <tr>
                    <th>File</th>
                    <th>Type</th>
                    <th>Requirement</th>

                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Site.master</td>
                    <td>Master page</td>
                    <td>Site-wise layout</td>
                </tr>
                <tr>
                    <td>Content/*.css</td>
                    <td>Stylesheet, font-icons</td>
                    <td>Materialize-css styles files</td>
                </tr>
                <tr>
                    <td>Login.aspx</td>
                    <td>Web Form</td>
                    <td>User login, Validators-Required</td>
                </tr>
                <tr>
                    <td>Register.aspx</td>
                    <td>Web Form</td>
                    <td>User Registration, Validators-Required, Compare</td>
                </tr>
                <tr>
                    <td>Secured/Web.config</td>
                    <td>Configuration</td>
                    <td>Anonymous access restrction</td>
                </tr>
                <tr>
                    <td>Secured/MasterDetailData.aspx</td>
                    <td>Web Form</td>
                    <td>Master-Detail Navigation</td>
                </tr>
                <tr>
                    <td>Secured/MasterDetailDataUC.ascx</td>
                    <td>Web User Control</td>
                    <td>User control</td>
                </tr>
                <tr>
                    <td>Secured/Departments.aspx</td>
                    <td>Web Form</td>
                    <td>CRUD activities/Related data navigation, AJAX, AJAX Progress Indication,Validators-Required,Datatype check</td>
                </tr>
                <tr>
                    <td>Secured/EmplyeeCRUD.aspx</td>
                    <td>Web Form</td>
                    <td>CRUD activities, Validators-Required, RegularExpression</td>
                </tr>
                <tr>
                    <td>Secured/ReportCR.rpt</td>
                    <td>Crystal Report</td>
                    <td>Grouped Report</td>
                </tr>
                <tr>
                    <td>DAL/*.cs</td>
                    <td>C# Code</td>
                    <td>Business Logic/Data Access</td>
                </tr>
            </tbody>
        </table>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
