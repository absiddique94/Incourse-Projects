<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmplyeeCRUD.aspx.cs" Inherits="HR_Project.Secured.EmplyeeCRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <h4>Departments</h4>

    <asp:ListView ID="ListView1" runat="server" DataSourceID="dsEmployees" InsertItemPosition="LastItem">

        <EditItemTemplate>
            <tr style="">
                <td class="center">
                    <asp:LinkButton ID="UpdateButton" CssClass="btn-floating btn-large waves-effect waves-light btn-small blue-grey" ValidationGroup="update" runat="server" CommandName="Update"><i class="material-icons">save</i></asp:LinkButton>
                    <asp:LinkButton ID="CancelButton" CssClass="btn-floating btn-large waves-effect waves-light btn-small" CausesValidation="false" runat="server" CommandName="Cancel"><i class="material-icons">cancel</i></asp:LinkButton>
                </td>
                <td>
                    <asp:Label ID="EmployeeIdTextBox" ValidationGroup="update" runat="server" Text='<%# Bind("EmployeeId") %>' />
                </td>
                 <td>
                    <div class="input-field">
                        <asp:TextBox ID="EmployeeNameTextBox" runat="server" Text='<%# Bind("EmployeeName") %>' />
                        <asp:RequiredFieldValidator Display="Dynamic"  ValidationGroup="insert"  ControlToValidate="EmployeeNameTextBox"  CssClass="helper-text red-text" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name required."></asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div class="input-field">
                        <asp:TextBox ID="BasicSalaryTextBox" runat="server" Text='<%# Bind("BasicSalary") %>' />
                        <asp:RequiredFieldValidator Display="Dynamic"  ValidationGroup="insert"  ControlToValidate="BasicSalaryTextBox"  CssClass="helper-text red-text" ID="rvBasic" runat="server" ErrorMessage="Salary required."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvBasic" runat="server"  Display="Dynamic"  ValidationGroup="insert"  ControlToValidate="BasicSalaryTextBox" Operator="DataTypeCheck" Type="Double"  CssClass="helper-text red-text" ErrorMessage="Invalid value."></asp:CompareValidator>
                    </div>
                </td>
                <td>
                    <div class="input-field">
                        <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                        <asp:RequiredFieldValidator Display="Dynamic"  ValidationGroup="insert"  ControlToValidate="EmailTextBox"  CssClass="helper-text red-text" ID="rvMail" runat="server" ErrorMessage="Email required."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="helper-text red-text" ValidationGroup="insert" ID="reMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="Invalid e-mail."></asp:RegularExpressionValidator>
                    </div>
                </td>
                <td>
                    <div class="input-field">
                        <asp:DropDownList ValidationGroup="insert" SelectedValue='<%# Bind("DepartmentId") %>' ID="DepartmentIdDropDown" AppendDataBoundItems="true" runat="server" DataSourceID="dsDepartments" DataTextField="DepartmentName" DataValueField="DepartmentId">
                            <asp:ListItem Value="Select">--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="insert" InitialValue="Select"  ControlToValidate="DepartmentIdDropDown"  CssClass="helper-text red-text" ID="rvDeptId" runat="server" ErrorMessage="Dept. Id required."></asp:RequiredFieldValidator>
                    </div>
                </td>

            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td class="center">
                    <asp:LinkButton ID="InsertButton" ValidationGroup="insert" CssClass="btn-floating btn-large waves-effect waves-light btn-small pink" runat="server" CommandName="Insert"><i class="material-icons">add</i></asp:LinkButton>
                    <asp:LinkButton ID="CancelButton" CausesValidation="false" CssClass="btn-floating btn-large waves-effect waves-light btn-small" runat="server" CommandName="Cancel"><i class="material-icons">cancel</i></asp:LinkButton>
                </td>
                <td>
                    <asp:Label ID="EmployeeIdTextBox" runat="server" Text="[Generated]"/>
                </td>
                <td>
                    <div class="input-field">
                        <asp:TextBox ID="EmployeeNameTextBox" runat="server" Text='<%# Bind("EmployeeName") %>' />
                        <asp:RequiredFieldValidator Display="Dynamic"  ValidationGroup="insert"  ControlToValidate="EmployeeNameTextBox"  CssClass="helper-text red-text" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name required."></asp:RequiredFieldValidator>
                    </div>
                </td>
                <td>
                    <div class="input-field">
                        <asp:TextBox ID="BasicSalaryTextBox" runat="server" Text='<%# Bind("BasicSalary") %>' />
                        <asp:RequiredFieldValidator Display="Dynamic"  ValidationGroup="insert"  ControlToValidate="BasicSalaryTextBox"  CssClass="helper-text red-text" ID="rvBasic" runat="server" ErrorMessage="Salary required."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvBasic" runat="server"  Display="Dynamic"  ValidationGroup="insert"  ControlToValidate="BasicSalaryTextBox" Operator="DataTypeCheck" Type="Double"  CssClass="helper-text red-text" ErrorMessage="Invalid value."></asp:CompareValidator>
                    </div>
                </td>
                <td>
                    <div class="input-field">
                        <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
                        <asp:RequiredFieldValidator Display="Dynamic"  ValidationGroup="insert"  ControlToValidate="EmailTextBox"  CssClass="helper-text red-text" ID="rvMail" runat="server" ErrorMessage="Email required."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" CssClass="helper-text red-text" ValidationGroup="insert" ID="reMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="Invalid e-mail."></asp:RegularExpressionValidator>
                    </div>
                </td>
                <td>
                    <div class="input-field">
                        <asp:DropDownList ValidationGroup="insert" SelectedValue='<%# Bind("DepartmentId") %>' ID="DepartmentIdDropDown" AppendDataBoundItems="true" runat="server" DataSourceID="dsDepartments" DataTextField="DepartmentName" DataValueField="DepartmentId">
                            <asp:ListItem Value="Select">--Select--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ValidationGroup="insert"  InitialValue="Select" ControlToValidate="DepartmentIdDropDown"  CssClass="helper-text red-text" ID="rvDeptId" runat="server" ErrorMessage="Dept. Id required."></asp:RequiredFieldValidator>
                    </div>
                </td>

            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td class="center">
                    <asp:LinkButton ID="DeleteButton" ValidationGroup="edit" CssClass="btn-floating btn-large waves-effect waves-light btn-small red" runat="server" CommandName="Delete"><i class="material-icons">delete</i></asp:LinkButton>
                    <asp:LinkButton CausesValidation="false" CssClass="btn-floating btn-large waves-effect waves-light btn-small" ID="EditButton" runat="server" CommandName="Edit"><i class="material-icons">edit</i></asp:LinkButton>
                </td>
                <td>
                    <asp:Label ID="EmployeeIdLabel" runat="server" Text='<%# Eval("EmployeeId") %>' />
                </td>
                <td>
                    <asp:Label ID="EmployeeNameLabel" runat="server" Text='<%# Eval("EmployeeName") %>' />
                </td>
                <td>
                    <asp:Label ID="BasicSalaryLabel" runat="server" Text='<%# Eval("BasicSalary") %>' />
                </td>
                <td>
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                </td>

                <td>
                    <asp:Label ID="DepartmentLabel" runat="server" Text='<%# Eval("Department.DepartmentName") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>

            <table>
                <thead>
                    <tr runat="server" style="">
                        <th></th>
                        <th>
                            <asp:LinkButton CssClass="btn btn-flat" CausesValidation="false" ID="LinkButton1" runat="server" CommandName="Sort" CommandArgument="EmployeeId"><i class="material-icons right">sort</i>Employee Id</asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton CssClass="btn btn-flat" CausesValidation="false" ID="LinkButton2" runat="server" CommandName="Sort" CommandArgument="EmployeeName"><i class="material-icons right">sort_by_alpha</i>Employee Name</asp:LinkButton>
                        </th>
                        <th>
                            <asp:LinkButton CssClass="btn btn-flat" CausesValidation="false" ID="LinkButton3" runat="server" CommandName="Sort" CommandArgument="BasicSalary"><i class="material-icons right">sort</i>Basic Salary</asp:LinkButton>
                        </th>
                        <th>Email</th>

                        <th>Department</th>
                    </tr>
                </thead>
                <tbody id="itemPlaceholder" runat="server">
                </tbody>
                <tfoot>
                    <tr >
                        <td colspan="7" class="center">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonCssClass="btn btn-flat" ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" NextPageText=">>" LastPageText=">|" FirstPageText="|<" PreviousPageText="<<" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </tfoot>
            </table>



        </LayoutTemplate>

    </asp:ListView>
    <div>
    </div>
    <asp:ObjectDataSource ID="dsEmployees" runat="server"
        DataObjectTypeName="HR_Project.Models.Employee" DeleteMethod="DeleteEmployee"
        EnablePaging="True" InsertMethod="InsertEmployee" SelectCountMethod="GetEmployeeCount"
        SelectMethod="GetEmployees" TypeName="HR_Project.DAL.DbDataAccess"
        UpdateMethod="UpdateEmployee" SortParameterName="sortExpression"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsDepartments" runat="server" SelectMethod="GetDepartmentList" TypeName="HR_Project.DAL.DbDataAccess"></asp:ObjectDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script>
       
    $('select').formSelect();
  
    </script>
</asp:Content>
