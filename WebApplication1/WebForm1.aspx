<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>
        SSI_IOT
    </title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Height="53px" OnClick="Button1_Click" Text="Refresh" Width="120px" />
        </div>
        <p>
            Temperature: <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            PA:
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            RotationX:
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        </p>
        RotationY:
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <p>
            RotationZ:
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
