<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ConCung.Pages.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        margin-left: 518px;
    }
    .auto-style3 {
        margin-left: 440px;
    }
    .auto-style4 {
        margin-left: 14px;
    }
    .auto-style5 {
        margin-left: 400px;
    }
    .auto-style6 {
        margin-left: 480px;
    }
    .auto-style7 {
        margin-left: 280px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style7">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
</p>
    <p class="auto-style5">
        &nbsp;&nbsp;&nbsp;&nbsp;
        Số điện thoại:<asp:TextBox ID="txtPhoneNum" runat="server" CssClass="inputs"></asp:TextBox>
    </p>
<p class="auto-style3">
        Mật khẩu:<asp:TextBox ID="txtPass" runat="server" CssClass="inputs" Height="16px" TextMode="Password"></asp:TextBox>
    </p>
<p>
        <asp:Button ID="btnLogin" runat="server" CssClass="auto-style1" OnClick="btnLogin_Click" Text="Đăng nhập" Width="128px" />
    </p>
<p class="auto-style6">
        <asp:LinkButton ID="lbtnRegister" runat="server" OnClick="lbtnRegister_Click">Chưa có tài khoản? Đăng ký ngay</asp:LinkButton>
    </p>
</asp:Content>
