<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="userHomePage.aspx.cs" Inherits="AndroShield.Web_Forms.userHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="navContentPlaceHolder" runat="server">
    
    <asp:Button ID="signupNav" runat="server" Text="My Profile" class="topRight topMenu lightText" CausesValidation="false" OnClick="signupNav_Click"/>
    <asp:Button ID="logoutButton" runat="server" Text="Log Out"  class="topRight topMenu lightText" CausesValidation="false" OnClick="logoutButton_Click"/>

    <asp:HyperLink ID="userEmail" class="lightText top" runat="server" NavigateUrl="~/Web Forms/userProfilePage.aspx">HyperLink</asp:HyperLink><p class="lightText top">Welcome, </p>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
        <div class="wrapper lightBackground">
            <div class="row">
                <div class="twoColumns">
                    <asp:Button ID="uploadApkButton" runat="server" Text="Upload Apk" class="userHomePageButtons boldText" OnClick="uploadApkButton_Click"/>
                </div>
                <div class="twoColumns">
                    <asp:Button ID="viewReportsButton" runat="server" Text="View Reports" class="userHomePageButtons boldText"/>
                </div>
            </div>
        </div>
</asp:Content>
