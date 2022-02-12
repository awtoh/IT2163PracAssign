<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IT2163PracAssign.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="https://www.google.com/recaptcha/api.js?render=6Lf0I3AeAAAAACz_93vCh8yYdM7IaU04kohhT2ET"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
    <h2>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Account Login"></asp:Label>
        <br />
        <br />
   </h2>
        <table class="style1">
            <tr>
                <td class="style3">
        <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="tb_fn" runat="server" Height="36px" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
        <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="tb_pwd" runat="server" input type="password" Height="32px" Width="281px"></asp:TextBox>
                </td>
            </tr>
        </table>
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Login" Height="27px" Width="133px" />
            <br />
            <br />
            <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response"/>

            <asp:Label ID="lblMessage" runat="server" EnableViewState="False" >Error message here (lblMessage)</asp:Label>
        </div>
    </form>
    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6Lf0I3AeAAAAACz_93vCh8yYdM7IaU04kohhT2ET', { action: 'Login' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            })
        })
    </script>
</body>
</html>
