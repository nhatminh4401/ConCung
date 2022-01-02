<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageProductType.aspx.cs" Inherits="ConCung.Management.ManageProductType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Tên loại sản phẩm:</p>
    <p>
        <asp:TextBox ID="txtProductType" runat="server"></asp:TextBox>
    </p>
    Thuộc loại sản phẩm:<br />
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="TEN_LOAI" DataValueField="MA_LOAI">
        <asp:ListItem Selected="True" Value="NULL">Không</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 27px" Text="Không" Width="80px" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CONCUNGConnectionString %>" SelectCommand="SELECT * FROM [LOAISP] ORDER BY [TEN_LOAI]" ProviderName="<%$ ConnectionStrings:CONCUNGConnectionString.ProviderName %>"></asp:SqlDataSource>
    <br />
    <br />
    <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Xác nhận" />
    <br />
    <br />
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</asp:Content>
