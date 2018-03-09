<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="user'sReportsPage.aspx.cs" Inherits="AndroApp.Web_Forms.user_sReportsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navContentPlaceHolder" runat="server">
    <asp:Button ID="signupNav" runat="server" Text="My Profile" class="topRight topMenu lightText" CausesValidation="false" OnClick="signupNav_Click"/>
    <asp:Button ID="logoutButton" runat="server" Text="Log Out"  class="topRight topMenu lightText" CausesValidation="false" OnClick="logoutButton_Click"/>

    <asp:HyperLink ID="userEmail" class="lightText top" runat="server" NavigateUrl="~/Web Forms/userProfilePage.aspx">HyperLink</asp:HyperLink><p class="lightText top">Welcome, </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageContent" runat="server">
        <div id="allReportContainer" class="wrapper lightBackground">
            <asp:Table ID="allReportsTable" runat="server">
                <asp:TableHeaderRow CssClass="vulnerabilityReportHeader">
                    <asp:TableHeaderCell CssClass="cell rightBorder" Width="200px">Apk Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="cell rightBorder" Width="200px">Package Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="cell rightBorder" Width="200px">Version Number</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="cell" Width="200px">Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="cell" Width="100px" ></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
</asp:Content>
