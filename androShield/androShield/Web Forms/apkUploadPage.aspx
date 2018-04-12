<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="apkUploadPage.aspx.cs" Inherits="AndroShield.Web_Forms.apkUploadPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="/Styling/StyleSheet.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
    <form id="apkUploadForm" runat="server" method="get">
        <div class="wrapper lightBackground">
                <div class="box">
					<input type="file" name="file-1[]" id="file-1" class="inputfile inputfile-1" data-multiple-caption="{count} files selected" multiple />
				</div>
        </div>
    </form>
</asp:Content>
