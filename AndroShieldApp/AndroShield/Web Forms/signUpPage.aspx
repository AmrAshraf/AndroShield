<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="signUpPage.aspx.cs" Inherits="AndroShield.Web_Forms.signUpPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">

    <div class="wrapper lightBackground">
        <div class="signUpContainer darkBackground">
            <h1 class="lightText boldText">Sign Up</h1>
            <p class="lightText">Please fill in this form to create an account.</p>
            <a href="homepage.aspx" class="lightText boldText">Already have an account?</a><asp:Button ID="loginButton" CausesValidation="false" runat="server" Text="Login" class="simpleButton lightText" OnClick="loginButton_Click"/>
            <hr>

            <label for="fname" class="boldText lightText ">First Name</label>
            <asp:TextBox ID="firstNameTxt" runat="server" placeholder="Enter First Name" name="fname" class="loginInput"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="firstNameTxt" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required Field" ForeColor="GhostWhite" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            
            <label for="lname" class="boldText lightText ">Last Name</label>
            <asp:TextBox ID="lastNameTxt" runat="server" placeholder="Enter Last Name" name="lname" class="loginInput"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="lastNameTxt" ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Required Field" ForeColor="GhostWhite" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator><br /><br />
            
            <label for="email" class="boldText lightText">Email</label>
            <asp:TextBox ID="emailTxt" runat="server" TextMode="Email" placeholder="Enter Email" name="email" class="loginInput"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="emailTxt" ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Required Field" ForeColor="GhostWhite" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="emailValidator" ControlToValidate="emailTxt" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Invalid Email" ForeColor="WhiteSmoke" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator><br /><br />

            <label for="psw" class="boldText lightText">Password</label>
            <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password" placeholder="Enter Password" name="psw" class="loginInput"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="passwordTxt" ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Required Field" ForeColor="GhostWhite" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator><br />
            
            <label for="psw-repeat" class="boldText lightText ">Repeat Password</label>
            <asp:TextBox ID="repasswordTxt" runat="server" TextMode="Password" placeholder="Repeat Password" name="psw-repeat" class="loginInput"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="repasswordTxt" ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Required Field" ForeColor="GhostWhite" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:CompareValidator ID="passwordCompareValidator" runat="server" ErrorMessage="Passwords must match" ControlToValidate="repasswordTxt" ControlToCompare="passwordTxt" Display="Dynamic" ForeColor="WhiteSmoke" SetFocusOnError="true"></asp:CompareValidator><br /><br />
            
            <asp:Button ID="signUpButton" runat="server" Text="Sign Up" class="homeButtons boldText" OnClick="signUpButton_Click"/>
        </div>
    </div>
</asp:Content>
