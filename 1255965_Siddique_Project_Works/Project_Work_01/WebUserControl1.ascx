<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="Project_Work_01.WebUserControl1" %>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="TeamId" DataSourceID="sdsTeams" InsertItemPosition="LastItem">
        
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button CssClass="btn-primary btn-sm"  ID="UpdateButton" ValidationGroup="ge" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button CssClass="btn-secondary btn-sm"  ID="CancelButton" CausesValidation="false" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:Label ID="TeamIdLabel1" runat="server" Text='<%# Eval("TeamId") %>' />
                </td>
               <td>
                    <asp:TextBox ID="TeamNameTextBox" ValidationGroup="ge" runat="server" Text='<%# Bind("TeamName") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ge" ControlToValidate="TeamNameTextBox" runat="server" ErrorMessage="TeamName Required"></asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="EmailTextBox" ValidationGroup="ge" runat="server" Text='<%# Bind("Email") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="ge" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="ge" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="Email Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

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
                <td>
                    <asp:Button CssClass="btn-success btn-sm"  ID="InsertButton" ValidationGroup="gi" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button CssClass="btn-secondary btn-sm"  ID="CancelButton" CausesValidation="false" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>[Generated]</td>
                <td>
                    <asp:TextBox ID="TeamNameTextBox" ValidationGroup="gi" runat="server" Text='<%# Bind("TeamName") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="gi" ControlToValidate="TeamNameTextBox" runat="server" ErrorMessage="TeamName Required"></asp:RequiredFieldValidator>

                </td>
                <td>
                    <asp:TextBox ID="EmailTextBox" ValidationGroup="gi" runat="server" Text='<%# Bind("Email") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ValidationGroup="gi" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="Email Required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="gi" ControlToValidate="EmailTextBox" runat="server" ErrorMessage="Email Invalid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button CssClass="btn-danger btn-sm"  ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button CssClass="btn-success btn-sm"  ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="TeamIdLabel" runat="server" Text='<%# Eval("TeamId") %>' />
                </td>
                <td>
                    <asp:Label ID="TeamNameLabel" runat="server" Text='<%# Eval("TeamName") %>' />
                </td>
                <td>
                    <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table class="table" runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table class="table table-bordered" id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server">Action</th>
                                <th runat="server">TeamId</th>
                                <th runat="server">TeamName</th>
                                <th runat="server">Email</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style=""></td>
                </tr>
            </table>
        </LayoutTemplate>
        
    </asp:ListView>
    <asp:SqlDataSource ID="sdsTeams" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Teams] WHERE [TeamId] = @TeamId" InsertCommand="INSERT INTO [Teams] ([TeamName], [Email]) VALUES (@TeamName, @Email)" SelectCommand="SELECT * FROM [Teams]" UpdateCommand="UPDATE [Teams] SET [TeamName] = @TeamName, [Email] = @Email WHERE [TeamId] = @TeamId">
        <DeleteParameters>
            <asp:Parameter Name="TeamId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="TeamName" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="TeamName" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="TeamId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>