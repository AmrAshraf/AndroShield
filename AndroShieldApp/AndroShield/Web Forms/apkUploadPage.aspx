<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="apkUploadPage.aspx.cs" Inherits="AndroApp.Web_Forms.apkUploadPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Styling/StyleSheet.css" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="navContentPlaceHolder" runat="server">
    <asp:Button ID="signupNav" runat="server" Text="My Profile" class="topRight topMenu lightText" CausesValidation="false" OnClick="signupNav_Click"/>
    <asp:Button ID="logoutButton" runat="server" Text="Log Out"  class="topRight topMenu lightText" CausesValidation="false" OnClick="logoutButton_Click"/>

    <asp:HyperLink ID="userEmail" class="lightText top" runat="server" NavigateUrl="~/Web Forms/userProfilePage.aspx">HyperLink</asp:HyperLink><p class="lightText top">Welcome, </p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
    <div class="wrapper lightBackground">
            <div class="apkUploadContainer incorrectCredentialsContainer darkBackground lightText">
                <asp:FileUpload ID="apkUpload" name="apkUpload" runat="server" class="inputfile"/>
                <%--<asp:Label ID="browseLbl" CssClass="homeButtons lightText boldText" AssociatedControlID="apkUpload" runat="server" Text="Browse"></asp:Label><br />--%>
                <asp:Button ID="uploadBtn" CssClass="homeButtons lightText boldText" runat="server" Text="Upload" OnClick="uploadBtn_Click"/><br />
                <asp:Button ID="analyzeBtn" CssClass="homeButtons lightText boldText" runat="server" Text="Analyze" Enabled="false" OnClick="analyzeBtn_Click"/>
            </div>
    </div>
</asp:Content>
