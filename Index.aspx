<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ConCung.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CONCUNGConnectionString %>" SelectCommand="SELECT * FROM [SANPHAM] ORDER BY [TEN_SP]" ProviderName="<%$ ConnectionStrings:CONCUNGConnectionString.ProviderName %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CONCUNGConnectionString %>" SelectCommand="SELECT * FROM [SANPHAM] WHERE [MA_LOAI] = @productType ORDER BY [TEN_SP]" ProviderName="<%$ ConnectionStrings:CONCUNGConnectionString.ProviderName %>" OnSelecting="SqlDataSource2_Selecting">
        <SelectParameters>
            <asp:Parameter Name="productType" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Chọn loại sản phẩm:<br />
    <asp:DropDownList ID="ddlType" runat="server" CssClass="inputs" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" Width="152px" DataSourceID="SqlDataSource3" DataTextField="TEN_LOAI" DataValueField="MA_LOAI" AppendDataBoundItems = "true" AutoPostBack="true">
        <asp:ListItem Selected="True" Value="All">Tất cả</asp:ListItem>
        </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CONCUNGConnectionString %>" SelectCommand="SELECT * FROM [LOAISP] ORDER BY [TEN_LOAI]" ProviderName="<%$ ConnectionStrings:CONCUNGConnectionString.ProviderName %>"></asp:SqlDataSource>
    <asp:Panel ID="pnlProducts" runat="server" >
    </asp:Panel>
    <div style="clear: both"></div>
</asp:Content>
