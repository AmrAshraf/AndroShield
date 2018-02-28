<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="userHomePage.aspx.cs" Inherits="AndroShield.Web_Forms.userHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
    <form runat="server">
        <div class="wrapper lightBackground">
            <div class="row">
                <div class="twoColumns">
                    <asp:Button ID="uploadApkButton" runat="server" Text="Upload Apk" class="userHomePageButtons boldText"/>
                </div>
                <div class="twoColumns">
                    <asp:Button ID="viewReportsButton" runat="server" Text="View Reports" class="userHomePageButtons boldText"/>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
