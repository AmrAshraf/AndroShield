﻿<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="userProfilePage.aspx.cs" Inherits="AndroShield.Web_Forms.userProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navContentPlaceHolder" runat="server">
    <input name="signup" type="button" id="signupNavUser" runat="server" class="topRight topMenu lightText" value="My Profile" CausesValidation="false"/>
    <input name="logoutBtn" type="button" id="logoutButtonUser" runat="server" onserverclick="Logout"  class="topRight topMenu lightText" value="Log Out" CausesValidation="false" />
    <asp:HyperLink ID="userEmail" class="lightText top" runat="server" NavigateUrl="~/Web Forms/userProfilePage.aspx">HyperLink</asp:HyperLink><p class="lightText top">Welcome, </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageContent" runat="server">
</asp:Content>
