<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MasterDetailDataUC.ascx.cs" Inherits="HR_Project.Secured.MasterDetailDataUC" %>
<div class="row">
        <h4>Departments</h4>
        <asp:GridView  OnPreRender="GridView1_PreRender" ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="DepartmentId" DataSourceID="dsDept" SelectedIndex="0" PageSize="5" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:CommandField ShowSelectButton="True">
                <ControlStyle CssClass="btn btn-flat" />
                </asp:CommandField>
                <asp:BoundField DataField="DepartmentId" HeaderText="Department Id" InsertVisible="False" ReadOnly="True" SortExpression="DepartmentId" />
                <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" SortExpression="DepartmentName" />
            </Columns>
            <PagerStyle HorizontalAlign="Center" CssClass="center" />
            <PagerTemplate>
                <asp:Button 
                    ID="Button1" 
                    runat="server" 
                    Text="First" 
                    CommandName="First"
                    CssClass="btn btn-small"
                   
                    />
                <asp:Button 
                    ID="Button2" 
                    runat="server" 
                    Text="Next" 
                    CommandName="Next"
                    CssClass="btn btn-small"
                    />
                <asp:Button 
                    ID="Button3" 
                    runat="server" 
                    Text="Previous" 
                    CommandName="Previous"
                    CssClass="btn btn-small"
                    />
                <asp:Button 
                    ID="Button4" 
                    runat="server" 
                    Text="Last" 
                    CommandName="Last"
                   CssClass="btn btn-small"
                    />
            </PagerTemplate>
        </asp:GridView>
        <asp:SqlDataSource ID="dsDept" runat="server" ConnectionString="<%$ ConnectionStrings:hr %>" SelectCommand="SELECT * FROM [Departments]"></asp:SqlDataSource>
    </div>
    <div class="row">
        <h4>Employees</h4>
        <asp:GridView OnPreRender="GridView2_PreRender" ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="EmployeeId" DataSourceID="dsEmp" PageSize="5">
            <Columns>
                <asp:BoundField DataField="EmployeeId" HeaderText="Employee Id" InsertVisible="False" ReadOnly="True" SortExpression="EmployeeId" />
                <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="EmployeeName" />
                <asp:BoundField DataField="BasicSalary" DataFormatString="{0:0.00}" HeaderText="Basic Salary" SortExpression="BasicSalary" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="DepartmentId" HeaderText="Department Id" SortExpression="DepartmentId" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="dsEmp" runat="server" ConnectionString="<%$ ConnectionStrings:hr %>" SelectCommand="SELECT * FROM [Employees] WHERE ([DepartmentId] = @DepartmentId)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="DepartmentId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>