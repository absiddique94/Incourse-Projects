<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl2.ascx.cs" Inherits="Project_Work_01.WebUserControl2" %>
<asp:ListView ID="ListView1" runat="server" DataKeyNames="PlayerId" DataSourceID="sdsPlayers" InsertItemPosition="LastItem" OnItemInserting="ListView1_ItemInserting" OnItemUpdating="ListView1_ItemUpdating">
        
        <EditItemTemplate>
            <tr style="">
                <td class="col-2">
                    <asp:Button CssClass="btn-outline-primary btn-sm"  ID="UpdateButton" ValidationGroup="ge" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button class="btn-outline-secondary btn-sm" ID="CancelButton" CausesValidation="false" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td class="col-1">
                    <asp:Label ID="PlayerIdLabel1" runat="server" Text='<%# Eval("PlayerId") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PlayerNameTextBox" ValidationGroup="ge" runat="server" Text='<%# Bind("PlayerName") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ge" ControlToValidate="PlayerNameTextBox" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Image ID="PictureTextBox" Width="40px" validationGroup="ge" runat="server" ImageUrl='<%# Eval("Picture", "~/Uploads/{0}") %>' />
                    <asp:HiddenField ID="HiddenField1" runat="server" value='<%# Bind("Picture") %>' /> 
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" ValidationGroup="ge" SelectedValue='<%# Bind("TeamId") %>' DataSourceID="sdsTeam" DataTextField="TeamName" DataValueField="TeamId">
                    </asp:DropDownList>
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
                <td class="col-2">
                    <asp:Button CssClass="btn-outline-success" ID="InsertButton" ValidationGroup="gi" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button CssClass="btn-outline-secondary" ID="CancelButton" CausesValidation="false" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td> [Auto] </td>
                <td>
                    <asp:TextBox ID="PlayerNameTextBox" ValidationGroup="gi" runat="server" Text='<%# Bind("PlayerName") %>' />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="gi" ControlToValidate="PlayerNameTextBox" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:HiddenField ID="HiddenField1" runat="server" value='<%# Bind("Picture") %>' /> 
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="gi" ControlToValidate="FileUpload1" runat="server" ErrorMessage="Required Picture"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" ValidationGroup="gi" SelectedValue='<%# Bind("TeamId") %>' DataSourceID="sdsTeam" DataTextField="TeamName" DataValueField="TeamId">
                    </asp:DropDownList>
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td class="col-2">
                    <asp:Button CssClass="btn-outline-info btn-sm" ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                    <asp:Button CssClass="btn-outline-danger btn-sm" ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                </td>
                <td class="col-1">
                    <asp:Label ID="PlayerIdLabel" runat="server" Text='<%# Eval("PlayerId") %>' />
                </td>
                <td>
                    <asp:Label ID="PlayerNameLabel" runat="server" Text='<%# Eval("PlayerName") %>' />
                </td>
                <td>
                    <asp:Image ID="PictureTextBox" Width="40px" validationGroup="ge" runat="server" ImageUrl='<%# Eval("Picture", "~/Uploads/{0}") %>' />
                </td>
                <td class="col-1">
                    <asp:Label ID="TeamIdLabel" runat="server" Text='<%# Eval("TeamId") %>' />
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
                                <th runat="server">PlayerId</th>
                                <th runat="server">PlayerName</th>
                                <th runat="server">Picture</th>
                                <th runat="server">TeamId</th>
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
    <asp:SqlDataSource ID="sdsPlayers" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Players] WHERE [PlayerId] = @PlayerId" InsertCommand="INSERT INTO [Players] ([PlayerName], [Picture], [TeamId]) VALUES (@PlayerName, @Picture, @TeamId)" SelectCommand="SELECT * FROM [Players]" UpdateCommand="UPDATE [Players] SET [PlayerName] = @PlayerName, [Picture] = @Picture, [TeamId] = @TeamId WHERE [PlayerId] = @PlayerId">
        <DeleteParameters>
            <asp:Parameter Name="PlayerId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="PlayerName" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="TeamId" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="PlayerName" Type="String" />
            <asp:Parameter Name="Picture" Type="String" />
            <asp:Parameter Name="TeamId" Type="Int32" />
            <asp:Parameter Name="PlayerId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsTeam" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Teams]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsTeams" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Teams]"></asp:SqlDataSource>