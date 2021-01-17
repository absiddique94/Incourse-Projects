<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Work_03.aspx.cs" Inherits="Project_Work_01.Work_03" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
        <h4>Teams</h4>
    <asp:GridView CssClass="table table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TeamId" DataSourceID="sdsTeams">
        <SelectedRowStyle CssClass="bg-secondary" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="TeamId" HeaderText="TeamId" InsertVisible="False" ReadOnly="True" SortExpression="TeamId" />
            <asp:BoundField DataField="TeamName" HeaderText="TeamName" SortExpression="TeamName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        </Columns>
    </asp:GridView>
        <asp:SqlDataSource ID="sdsTeams" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Teams]"></asp:SqlDataSource>
    <h4>Players</h4>
    <asp:GridView CssClass="table table-bordered" ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="PlayerId" DataSourceID="sdsPlayers" SelectedIndex="0">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="PlayerId" HeaderText="PlayerId" InsertVisible="False" ReadOnly="True" SortExpression="PlayerId" />
            <asp:BoundField DataField="PlayerName" HeaderText="PlayerName" SortExpression="PlayerName" />
            <asp:TemplateField HeaderText="Picture" SortExpression="Picture">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Picture") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="PictureTextBox" Width="40px" validationGroup="ge" runat="server" ImageUrl='<%# Eval("Picture", "~/Uploads/{0}") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TeamId" HeaderText="TeamId" SortExpression="TeamId" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsPlayers" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Players] WHERE ([TeamId] = @TeamId)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="TeamId" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
