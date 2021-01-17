<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project_Work_01.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="jumbotron" style="text-align:center; background-color:greenyellow">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>

        <h4>Welcome to my Project</h4>  
        <h4 >Submitted By:</h4>
        <b>Mohammad Abu Bakar Siddique <br />ID: 1255965 <br />Round: 43 <br />Batch Id: ESAD-CS/ACSL/43/01</b>
    </div>
    <div class="row">
        <div class="col-md-4" style="background-color:lightseagreen;">
            <h2>Requirements</h2>
            <p>
               Navigation, User Control, Site Responsive, CRUD, Authentication & Authorization, Crystal report including grouping & group summary, Validation, Multi-table Database, Date Picker, Checkbox, Paging & Sorting, Master-detail, Select, Application/Session Variable and Ajax. 
            </p>
        </div>
        <div class="col-md-4" style="background-color:lightblue;">
            <h2>Project Information</h2>
            <p>
                This project created with ASP.NET. You can see players list, teams name and their summery. you can edit, update and delete any player's and team's information.  
            </p>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
