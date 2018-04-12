<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="userProfilePage.aspx.cs" Inherits="AndroApp.Web_Forms.userProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navContentPlaceHolder" runat="server">
    <asp:Button ID="signupNav2" runat="server" Text="My Profile" class="topRight topMenu lightText" CausesValidation="false" OnClick="signupNav2_Click"/>
    <asp:Button ID="logoutButton" runat="server" Text="Log Out"  class="topRight topMenu lightText" CausesValidation="false" OnClick="logout_Click"/>

    <asp:HyperLink ID="userEmail" class="lightText top" runat="server" NavigateUrl="~/Web Forms/userProfilePage.aspx">HyperLink</asp:HyperLink><p class="lightText top">Welcome, </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageContent" runat="server">
        <div class="wrapper lightBackground">
        <div class="signUpContainer darkBackground">
            <h1 class="lightText boldText">Profile</h1>
            <p class="lightText boldText">Edit the following fields to update your profile</p>
            <hr>
            <label for="fname" class="boldText lightText ">First Name</label>
            <asp:TextBox ID="firstNameTxt" runat="server" name="fname" class="loginInput"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="firstNameTxt" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required Field" ForeColor="GhostWhite" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            
            <label for="lname" class="boldText lightText ">Last Name</label>
            <asp:TextBox ID="lastNameTxt" runat="server"  name="lname" class="loginInput"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="lastNameTxt" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required Field" ForeColor="GhostWhite" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator><br /><br />
            

            <label for="old-psw" class="boldText lightText">Old Password</label>
            <asp:TextBox ID="passwordTxt"  runat="server" TextMode="Password" name="psw" class="loginInput"></asp:TextBox><asp:Label ID="incorrectPasswordMsg" class="lightText" runat="server" Text="Label" Visible="false">*Incorrect Password</asp:Label><br />
            
            <label for="new-repeat" class="boldText lightText ">New Password</label>
            <asp:TextBox ID="newPassword"    runat="server" TextMode="Password"  name="psw-repeat" class="loginInput"></asp:TextBox><br />
            
            <label for="new-repeat" class="boldText lightText ">Password Repeat</label>
            <asp:TextBox ID="newRepeat"   runat="server" TextMode="Password" name="psw-repeat" class="loginInput"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Passwords must match" ControlToValidate="newRepeat" ControlToCompare="newPassword" Display="Dynamic" ForeColor="WhiteSmoke" SetFocusOnError="true"></asp:CompareValidator><br />
            <br />
            <asp:Button ID="updateBtn"  class="homeButtons lightText boldText" runat="server" Text="Update" OnClick="updateBtn_Click"/>
            <asp:Button ID="resetBtn"  class="homeButtons lightText boldText" runat="server" Text="Reset" OnClick="resetBtn_Click"/>
        </div>
    </div>
</asp:Content>