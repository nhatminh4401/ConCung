<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="ConCung.Management.ManageProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Tên sản phẩm:</p>
    <p>
        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
    </p>
    <p>
        Mô tả:</p>
    <p>
        <asp:TextBox ID="txtDescription" runat="server" Height="79px" TextMode="MultiLine" Width="405px"></asp:TextBox>
    </p>
    <p>
        Loại sản phẩm:</p>
    <p>
    <asp:DropDownList ID="ddlProductType" runat="server" DataSourceID="SqlDataSourceProduct" DataTextField="TEN_LOAI" DataValueField="MA_LOAI" Width="112px">
        <asp:ListItem Selected="True" Value="NULL">Không</asp:ListItem>
    </asp:DropDownList>
    </p>
    <asp:SqlDataSource ID="SqlDataSourceProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CONCUNGConnectionString %>" SelectCommand="SELECT * FROM [LOAISP] ORDER BY [TEN_LOAI]" ProviderName="<%$ ConnectionStrings:CONCUNGConnectionString.ProviderName %>"></asp:SqlDataSource>
    <br />
    Thương hiệu:<br />
    <asp:DropDownList ID="ddlBrand" runat="server" DataSourceID="SqlDataSourceBrand" DataTextField="TEN_TH" DataValueField="MA_TH" Width="112px">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSourceBrand" runat="server" ConnectionString="<%$ ConnectionStrings:CONCUNGConnectionString %>" SelectCommand="SELECT * FROM [THUONGHIEU] ORDER BY [TEN_TH]"></asp:SqlDataSource>
    <br />
    Combo:<br />
    <asp:CheckBox ID="cboxCombo" runat="server" />
    <br />
    <br />
    Mã khuyến mãi:<br />
    <asp:DropDownList ID="ddlSale" runat="server" DataSourceID="SqlDataSourceSale" DataTextField="TEN_PHIEU" DataValueField="MA_PHIEU">
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 27px" Text="Không" Width="80px" />
    <asp:SqlDataSource ID="SqlDataSourceSale" runat="server" ConnectionString="<%$ ConnectionStrings:CONCUNGConnectionString %>" SelectCommand="SELECT * FROM [PHIEUGGQT] ORDER BY [TEN_PHIEU]"></asp:SqlDataSource>
    <br />
    Giá:<br />
    <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox>
    <br />
    <br />
    Số lượng tồn kho:<br />
    <asp:TextBox ID="txtAmount" runat="server" TextMode="Number"></asp:TextBox>
    <br />
    <br />
    Ảnh:<br />
    <asp:DropDownList ID="ddlImages" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Xác nhận" Width="95px" />
    <br />
    <br />
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</asp:Content>
