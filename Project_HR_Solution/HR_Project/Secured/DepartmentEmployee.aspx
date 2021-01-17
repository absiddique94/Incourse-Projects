<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentEmployee.aspx.cs" Inherits="HR_Project.Secured.DepartmentEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h4>Employees Of <%= GetDeptName(int.Parse(Request.QueryString["id"]))%> Department</h4>
    <asp:GridView  ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="EmployeeId" DataSourceID="dsEmployees" OnPreRender="GridView1_PreRender">
        <Columns>
            <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeId" />
            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="EmployeeName" />
            <asp:BoundField DataField="BasicSalary" DataFormatString="{0:0.00}" HeaderText="Basic Salary" SortExpression="BasicSalary" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
    </asp:GridView>
    <div>
        <a href="/Secured/Departments.aspx" class="waves-effect waves-teal btn-flat"><i class="material-icons left">keyboard_backspace</i>Back to department list</a>
    </div>
    <asp:SqlDataSource ID="dsEmployees" runat="server" ConnectionString="<%$ ConnectionStrings:hr %>" SelectCommand="SELECT * FROM [Employees] WHERE ([DepartmentId] = @DepartmentId)">
        <SelectParameters>
            <asp:QueryStringParameter Name="DepartmentId" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
