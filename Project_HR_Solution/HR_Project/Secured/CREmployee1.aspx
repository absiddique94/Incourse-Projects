<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CREmployee1.aspx.cs" Inherits="HR_Project.Secured.CREmployee1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h3>Report</h3>
        <div><a href="/Default.aspx">Back home</a></div>
        <hr />
        <div>
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        </div>
        <footer>
            <p>HR Employee Management</p>
        </footer>
    </form>
</body>
</html>
