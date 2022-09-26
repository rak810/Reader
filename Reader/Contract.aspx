<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract.aspx.cs" Inherits="Reader.Contract" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contract</title>
    <link href="Shared/css/Contract.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
                <h3 runat="server" onclick="redirectFunc('Home.aspx')">Reader</h3>
                <ul id="Ul1" runat="server">
                    <li id="Li1" runat="server" onclick="redirectFunc('About.aspx')">
                        Our Story
                    </li>
                    <li id="Li2" runat="server" onclick="redirectFunc('Contract.aspx')">Contact</li>
                    <li id="Li3" runat="server" onclick="redirectFunc('Signin.aspx')">Sign In</li>
                </ul>
                 <a id="A1" href="#" runat="server" onclick="redirectFunc('Register.aspx')">Get Started</a>
            </header>
        <main>
            <div class="hero-text">
                <h1>Get in touch</h1>
                <p>Feel free to get in touch with ous. We would love to have a converstion with you.</p>
            </div>

            <div class="form-div">
                <input type="text" name="name" id="name" placeholder="Your Name">
                <input type="email" name="email" id="email" placeholder="Your Email">
                <textarea name="message" id="msg" cols="30" rows="8" placeholder="Your Message"></textarea>
                <a href="#"> Send </a>
            </div>
        </main>
    </form>
    <script>
        function redirectFunc(url) {
            window.location.href = url;
        }
    </script>
</body>
</html>
