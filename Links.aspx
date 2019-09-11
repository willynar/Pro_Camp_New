<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Links.aspx.cs" Inherits="Links" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server"
            NavigateUrl="~/salesreportsummary/2010">
    Sales Report - All locales, 2010
        </asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server"
            NavigateUrl="~/salesreport/WA/2011">
    Sales Report - WA, 2011
        </asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server"
            NavigateUrl="~/expensereport">
    Expense Report - Default Locale and Year (US, current year)
        </asp:HyperLink>
        <br />
    </div>
</asp:Content>

