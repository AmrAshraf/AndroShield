<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage.Master" AutoEventWireup="true" CodeBehind="aboutPage.aspx.cs" Inherits="AndroApp.Web_Forms.aboutPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navContentPlaceHolder" runat="server">

    <asp:Button ID="signupNav" runat="server" Text="My Profile" class="topRight topMenu lightText" CausesValidation="false" OnClick="signupNav_Click"/>
    <asp:Button ID="logoutButton" runat="server" Text="Log Out"  class="topRight topMenu lightText" CausesValidation="false" OnClick="logoutButton_Click"/>

    <asp:HyperLink ID="userEmail" class="lightText top" runat="server" NavigateUrl="~/Web Forms/userProfilePage.aspx">HyperLink</asp:HyperLink><p id="welcomeLabel" runat="server" class="lightText top">Welcome, </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageContent" runat="server">
    <div class="wrapper lightBackground">
        <div class="signUpContainer darkBackground">
            <h1 class="lightText boldText">About us</h1>
            <hr>
            <h2 class="lightText boldText">Who are we?</h2>
            <div class="miniContainer ">
                <hr>
                <div class="colum1">
                    <img class="smallIconAboutUs" src="../Images/GreenPeopleIcon.png" />
                </div>
                <div class="column2">
                    <p class="aboutUsP lightText boldText">We are four ambitious students who attended Software Engineering at Faculty of Computer And Information Science Ain Shams University 2014-2018.</p>
                </div>
            </div>
            <h2 class="lightText boldText">What's our goal?</h2>
            <div class="miniContainer">
                <hr>
                <div class="colum1">
                    <img class="smallIconAboutUs" src="../Images/questionMark.png" />
                </div>
                <div class="column2">
                    <p class="aboutUsP lightText boldText"> Our main goal with this project is to ensure the security of the users using Android applications and to facilitate the testing process for the Apps before release.</p>
                </div>
            </div>
            <h2 class="lightText boldText">Special Thanks</h2>
            <div class="miniContainer">
                <hr>
                <div class="colum1">
                    <img class="smallIconAboutUs" src="../Images/Vector-hand-in-hand-assistant-concept2014611_burned.png" />
                </div>
                <div class="column2">
                    <p class="aboutUsP lightText boldText">Our Appreciation and thanks go to our Supervisor Dr Islam Hegazy and our LA Hanan Yousry whose guidance, encouragement and knowledge helped us achieve this project.</p>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
