<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageProductBrand.aspx.cs" Inherits="ConCung.Management.ManageProductBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Tên thương hiệu:</p>
<p>
    <asp:TextBox ID="txtBrand" runat="server"></asp:TextBox>
</p>
<p>
    Xuất xứ:</p>
<p>
    <asp:TextBox ID="txtFromNation" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Xác nhận" Width="95px" />
</p>
<p>
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</p>
</asp:Content>
