<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="HR_Project.Secured.Departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px;
            background-color: #FFFFFF;
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=70);
            opacity: 0.70;
        }

        * html .overlay {
            position: absolute;
            height: expression(document.body.scrollHeight > document.body.offsetHeight ? document.body.scrollHeight : document.body.offsetHeight + 'px');
            width: expression(document.body.scrollWidth > document.body.offsetWidth ? document.body.scrollWidth : document.body.offsetWidth + 'px');
        }

        .loader {
            z-index: 100;
            position: fixed;
            width: 200px;
            margin-left: -100px;
            top: 50%;
            left: 50%;
        }

        * html .loader {
            position: absolute;
            margin-top: expression((document.body.scrollHeight / 4) + (0 - parseInt(this.offsetParent.clientHeight / 2) + (document.documentElement && document.documentElement.scrollTop || document.body.scrollTop)) + 'px');
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                    <div class="overlay">
                        <div class="loader">
                            <div class="preloader-wrapper big active">
                                <div class="spinner-layer spinner-blue-only">
                                    <div class="circle-clipper left">
                                        <div class="circle"></div>
                                    </div>
                                    <div class="gap-patch">
                                        <div class="circle"></div>
                                    </div>
                                    <div class="circle-clipper right">
                                        <div class="circle"></div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <h4>Departments</h4>
            <asp:ListView ID="lvDepartments" runat="server" DataKeyNames="DepartmentId" DataSourceID="dsDepartments"
                InsertItemPosition="LastItem" OnSorting="lvDepartments_Sorting">

                <EditItemTemplate>
                    <tr style="">
                        <td class="center">
                            <asp:LinkButton ID="UpdateButton" CssClass="btn-floating btn-large waves-effect waves-light btn-small blue-grey" ValidationGroup="update" runat="server" CommandName="Update"><i class="material-icons">save</i></asp:LinkButton>
                            <asp:LinkButton ID="CancelButton" CssClass="btn-floating btn-large waves-effect waves-light btn-small" CausesValidation="false" runat="server" CommandName="Cancel"><i class="material-icons">cancel</i></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="DepartmentIdTextBox" runat="server" Text='<%# Bind("DepartmentId") %>' />
                        </td>
                        <td>
                            <div class="input-field">
                                <asp:TextBox ID="DepartmentNameTextBox" ValidationGroup="update" runat="server" Text='<%# Bind("DepartmentName") %>' />
                                <asp:RequiredFieldValidator ValidationGroup="update" CssClass="helper-text red-text" ControlToValidate="DepartmentNameTextBox" ID="rvName" runat="server" ErrorMessage="Dept. Name required."></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td></td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>

                    <tr>
                        <td>No data was returned.</td>
                    </tr>

                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr style="">
                        <td class="center">
                            <asp:LinkButton ID="InsertButton" ValidationGroup="insert" CssClass="btn-floating btn-large waves-effect waves-light btn-small pink" runat="server" CommandName="Insert"><i class="material-icons">add</i></asp:LinkButton>
                            <asp:LinkButton ID="CancelButton" CausesValidation="false" CssClass="btn-floating btn-large waves-effect waves-light btn-small" runat="server" CommandName="Cancel"><i class="material-icons">cancel</i></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="DepartmentIdTextBox" runat="server" Text="[Auto-generated]" />

                        </td>
                        <td>
                            <div class="input-field">
                                <asp:TextBox ID="DepartmentNameTextBox" ValidationGroup="insert" runat="server" Text='<%# Bind("DepartmentName") %>' />
                                <asp:RequiredFieldValidator ValidationGroup="insert" CssClass="helper-text red-text" ControlToValidate="DepartmentNameTextBox" ID="rvName" runat="server" ErrorMessage="Dept. Name required."></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td></td>
                    </tr>
                </InsertItemTemplate>
                <ItemTemplate>
                    <tr style="">
                        <td class="center">
                            <asp:LinkButton ID="DeleteButton" ValidationGroup="edit" CssClass="btn-floating btn-large waves-effect waves-light btn-small red" runat="server" CommandName="Delete"><i class="material-icons">delete</i></asp:LinkButton>
                            <asp:LinkButton CausesValidation="false" CssClass="btn-floating btn-large waves-effect waves-light btn-small" ID="EditButton" runat="server" CommandName="Edit"><i class="material-icons">edit</i></asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="DepartmentIdLabel" runat="server" Text='<%# Eval("DepartmentId") %>' />
                        </td>
                        <td>
                            <asp:Label ID="DepartmentNameLabel" runat="server" Text='<%# Eval("DepartmentName") %>' />
                        </td>
                        <td>
                            <asp:HyperLink CssClass="waves-effect waves-teal btn-flat btn-small" ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("DepartmentId", "~/Secured/DepartmentEmployee.aspx?id={0}") %>'>Employees</asp:HyperLink>
                        </td>

                    </tr>
                </ItemTemplate>
                <LayoutTemplate>

                    <table>
                        <thead>
                            <tr runat="server" style="">
                                <th runat="server">Manipulate</th>
                                <th runat="server">
                                    <asp:LinkButton CssClass="btn btn-flat" CausesValidation="false" ID="LinkButton1" runat="server" CommandName="Sort" CommandArgument="DepartmentId"><i class="material-icons right">sort</i>Department Id</asp:LinkButton>
                                </th>
                                <th runat="server">
                                    <asp:LinkButton CssClass="btn btn-flat" CausesValidation="false" ID="LinkButton2" runat="server" CommandName="Sort" CommandArgument="DepartmentName"><i class="material-icons right">sort_by_alpha</i>Department Name</asp:LinkButton>
                                </th>
                                <th>View</th>
                            </tr>
                        </thead>
                        <tbody id="itemPlaceholder" runat="server">
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="4" class="center">
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

            <asp:ObjectDataSource ID="dsDepartments" runat="server"
                DataObjectTypeName="HR_Project.Models.Department"
                DeleteMethod="Delete" InsertMethod="InsertDepartment"
                SelectMethod="GetDepartments" TypeName="HR_Project.DAL.DbDataAccess"
                UpdateMethod="UpdateDepartment"
                EnablePaging="True" SelectCountMethod="GetDepartmentCount"
                SortParameterName="sortExpression"></asp:ObjectDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
