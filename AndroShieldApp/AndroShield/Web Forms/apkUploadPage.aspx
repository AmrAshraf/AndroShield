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
            <div class="apkUploadContainer  darkBackground lightText">
                <div class="inputContainer">
                    <asp:Image class="folderImage" runat="server" ImageUrl="~/Images/opened-folder.png" width="160px" Height="160px"/>
                    <asp:FileUpload ID="apkUpload" name="apkUpload" runat="server" class="inputfile"/><br />
                </div>
                <div class="container">
                    <asp:Button ID="analyzeBtn" CssClass="homeButtons lightText boldText uploadBtn" runat="server" Text="Analyze" OnClick="analyzeBtn_Click"/>
                </div>
            </div>
    </div>
</asp:Content>
