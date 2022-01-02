<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ConCung.Pages.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CONCUNGConnectionString %>" SelectCommand="SELECT * FROM [GIOHANG] WHERE [SDT]=@username" ProviderName="<%$ ConnectionStrings:CONCUNGConnectionString.ProviderName %>"  OnSelecting="SqlDataSource1_Selecting">
        <SelectParameters>
            <asp:Parameter Name="username" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Panel ID="pnlShoppingCart" runat="server">
    </asp:Panel>
    <table>
        <tr>
            <td>
                <b>Thành tiền: </b>
            </td>
            <td>
                <asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal>
            </td>
        </tr>

        <tr>
            <td>
                <b>VAT: </b>
            </td>
            <td>
                <asp:Literal ID="litVat" runat="server" Text="" />
            </td>
        </tr>

        <tr>
            <td>
                <b>Tổng tiền: </b>
            </td>
            <td>
                <asp:Literal ID="litTotalAmount" runat="server" Text="" />
            </td>
        </tr>

        <tr>
            <td>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Index.aspx" Font-Size="Large" ForeColor="Black">Tiếp tục mua sắm</asp:LinkButton>
                &nbsp;&nbsp; hay
                    <asp:Button ID="btnCheckout" runat="server" Text="Thanh toán" CssClass="button" Width="250px" OnClick="btnCheckout_Click" />

                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Literal ID="ltrStatusCheckout" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
