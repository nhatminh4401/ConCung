<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="ConCung.Pages.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 435px;
        }
        .auto-style2 {
            width: 435px;
            height: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td rowspan="4" style="width: 400px">
                <asp:Image ID="imgProduct" runat="server" CssClass="detailsImage" />
            </td>
            <td class="auto-style2">
                <h2>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
                <hr />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblDescription" runat="server" CssClass="detailsDescription"></asp:Label>
            </td>
            <td style="margin-left: 10px">
                <asp:Label ID="lblPrice" runat="server" CssClass="detailsPrice"></asp:Label>
                <br />
                <br />
                Số lượng:<asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList><br />
                <asp:Button ID="btnAdd" runat="server" Text="Đặt hàng" CssClass="button" OnClick="btnAdd_Click" />
                <br />
                <asp:Label ID="lblResult" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">Product No:
                <br />
                <asp:Label ID="lblItemNr" runat="server" Style="font-style: italic"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;<asp:Label ID="lblAvailable" runat="server" CssClass="productPrice">Available!</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
