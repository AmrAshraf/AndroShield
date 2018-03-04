<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="incorrectCredentialsPage.aspx.cs" Inherits="AndroShield.Web_Forms.incorrectCredentialsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="content3" ContentPlaceHolderID="navContentPlaceHolder" runat="server">
        <asp:Button ID="signupNav" runat="server" Text="My Profile" class="topRight topMenu lightText" CausesValidation="false" OnClick="signupNav_Click"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pageContent" runat="server">
        <div class="wrapper lightBackground">
            <div class="incorrectCredentialsContainer darkBackground">
                <p class="incorrectLoginCredentials lightText boldText">
                    <img src="../Images/x-symbol.png"/ id="xSymbol"> Incorrect Email or Password
                </p>
                <asp:RequiredFieldValidator ID="emailRequiredValidator" runat="server" ErrorMessage="*" ControlToValidate="emailTxt" SetFocusOnError="true" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator><label for="uname" class="boldText lightText negativeMargin">Email</label><asp:RegularExpressionValidator ID="emailValidator" ControlToValidate="emailTxt" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="*Invalid" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator><br />
                <asp:TextBox ID="emailTxt" runat="server" TextMode="Email" placeholder="Enter Email" name="uname" class="loginInput"></asp:TextBox>

                <asp:RequiredFieldValidator ID="passwordValidator" ControlToValidate="passwordTxt"  runat="server" ErrorMessage="*" ForeColor="Red" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator><label for="psw" class="boldText lightText negativeMargin">Password</label>
                <asp:TextBox ID="passwordTxt" runat="server" TextMode="Password" placeholder="Enter Password" name="psw" class="loginInput"></asp:TextBox>

                <label class="lightText loginInput">
                    <asp:CheckBox ID="CheckBox1" runat="server" checked="true"  name="remember"/>Remember me
                </label><br />

                <asp:Button ID="loginBtn" runat="server" Text="Login" class="homeButtons lightText boldText" OnClick="loginBtn_Click"  />
            </div>
        </div>
</asp:Content>
