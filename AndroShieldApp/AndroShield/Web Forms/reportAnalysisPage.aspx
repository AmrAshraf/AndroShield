<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="reportAnalysisPage.aspx.cs" Inherits="AndroApp.Web_Forms.reportAnalysisPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navContentPlaceHolder" runat="server">
        
    <asp:Button ID="signupNav" runat="server" Text="My Profile" class="topRight topMenu lightText" CausesValidation="false" OnClick="signupNav_Click"/>
    <asp:Button ID="logoutButton" runat="server" Text="Log Out"  class="topRight topMenu lightText" CausesValidation="false" OnClick="logoutButton_Click"/>

    <asp:HyperLink ID="userEmail" class="lightText top" runat="server" NavigateUrl="~/Web Forms/userProfilePage.aspx">HyperLink</asp:HyperLink><p class="lightText top">Welcome, </p>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageContent" runat="server">
    <div id="reportContainer" class="wrapper lightBackground">
        <div class="centeredButtons">
            <asp:Button ID="newAnalysisBtn" class="reportPageButtons boldText lightBackground" runat="server" Text="New Analysis" OnClick="newAnalysisBtn_Click"/>
            <asp:Button ID="allReportsBtn" class="reportPageButtons boldText lightBackground" runat="server" Text="All Reports" OnClick="allReportsBtn_Click" />
        </div>
        <p class="centeredClass " id="infoTitle">Apk Info</p>
        <div class="apkInfoContainer">
            <asp:Table ID="apkInfoTable" runat="server">
                <asp:TableRow CssClass="apkNameRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Apk Name</asp:TableHeaderCell>
                    <asp:TableCell ID="apkNameValue"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="apkVersionRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Apk Version</asp:TableHeaderCell>
                    <asp:TableCell ID="apkVersionValue"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="minSDKRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Minimum SDK</asp:TableHeaderCell>
                    <asp:TableCell ID="minSdkValue"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="targetSDKRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Target SDK</asp:TableHeaderCell>
                    <asp:TableCell ID="targetSdkValue" Width="170px"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="tetsOnlyRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Apk For Testing Only</asp:TableHeaderCell>
                    <asp:TableCell ID="testOnlyValue" Width="170px"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="packageNameRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Package Name</asp:TableHeaderCell>
                    <asp:TableCell ID="packageNameValue" Width="170px"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="versionNumberRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Version Number</asp:TableHeaderCell>
                    <asp:TableCell ID="versionNoValue" Width="170px"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="versionNameRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Version Name</asp:TableHeaderCell>
                    <asp:TableCell ID="versionNameValue" Width="170px"></asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow CssClass="debugModeRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Debug Mode Enabled</asp:TableHeaderCell>
                    <asp:TableCell ID="debugValue" Width="170px"></asp:TableCell>
                    </asp:TableRow>
                <asp:TableRow CssClass="backupModeRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Backup Mode Enabled</asp:TableHeaderCell>
                    <asp:TableCell ID="backupValue" Width="220px"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow CssClass="supportedArchiRow">
                    <asp:TableHeaderCell CssClass="cellHeader">Supported Architectures</asp:TableHeaderCell>
                    <asp:TableCell ID="supportedArchiValue" Width="220px"></asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
        <p class="centeredClass" id="vulnTitle">Vulnerabilities Report</p>
        <div class="vulnerabilityReportContainer">
            <asp:Table ID="vulnerabilityReportTable" runat="server">
                <asp:TableHeaderRow CssClass="vulnerabilityReportHeader">
                    <asp:TableHeaderCell CssClass="cell rightBorder" Width="200px">Risk Level</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="cell rightBorder" Width="200px">Category</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="cell rightBorder" Width="200px">Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell CssClass="cell" Width="470px">Description</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>
