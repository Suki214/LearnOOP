<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ColorShow.aspx.cs" Inherits="ColorShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        body {font-size :14px;}
        h1{font-size :26px;}
        #pnColors div{
            float:left ;width :140px;
            padding :7px 0;
            text-align:center;
            margin :3px;
            font-size:11px;
            border:1px solid #aaa;
            font-family :Verdana ,Arial
        }
    </style>
    <title></title>
</head>
<body>
    <h1>遍历System.Drawing.Color结构</h1>
    <form id="form1" runat="server">
        <asp:Panel ID="pnColors" runat ="server"></asp:Panel>
        <div>
        </div>
    </form>
</body>
</html>
