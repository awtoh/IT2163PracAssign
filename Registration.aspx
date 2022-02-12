<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="IT2163PracAssign._Registration" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Account Registration"></asp:Label>
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
        <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="tb_ln" runat="server" Height="32px" Width="281px"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="style3">
        <asp:Label ID="Label4" runat="server" Text="Credit Card"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="tb_cc" runat="server" Height="32px" Width="281px"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="style6">
        <asp:Label ID="Label5" runat="server" Text="Email address"></asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="tb_email" runat="server" Height="32px" Width="281px"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="style3">
        <asp:Label ID="Label6" runat="server" Text="Password"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="tb_pwd" runat="server" input type="password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{12,}" title="Must contain at least 1 number and 1 uppercase and lowercase letter, and at least 12 or more characters" required Height="32px" Width="281px"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="style3">
        <asp:Label ID="Label7" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="tb_dob" runat="server" placeholder="yyyy/mm/dd" Height="32px" Width="281px"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="style2">
        <asp:Label ID="Label8" runat="server" Text="Photo"></asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="tb_photo" runat="server" Height="32px" Width="281px"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="style4">
       
                </td>
                <td class="style5">
    <asp:Button ID="btn_Submit" runat="server" Height="48px" 
        onclick="btn_Submit_Click" Text="Submit" Width="288px"/>
                </td>
            </tr>
    </table>
&nbsp;<br />
        <asp:Label ID="lb_error1" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lb_error2" runat="server"></asp:Label>
    <br />
        <asp:Label ID="lb_error3" runat="server"></asp:Label>
    <br />
        <asp:Label ID="lb_error4" runat="server"></asp:Label>
    <br />
        <br />
    
    </div>
</asp:content>
