<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Reader.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reader</title>
    <link href="Shared/css/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<header>
        <h3 runat="server" onclick="redirectFunc('Home.aspx')">Reader</h3>
        <ul runat="server">
            <li runat="server" onclick="redirectFunc('About.aspx')">
                Our Story
            </li>
            <li runat="server" onclick="redirectFunc('Contract.aspx')">Contact</li>
            <li runat="server" onclick="redirectFunc('Signin.aspx')">Sign In</li>
        </ul>
         <a href="#" runat="server" onclick="redirectFunc('Register.aspx')">Get Started</a>
    </header>  
    <main class="container">
        <div class="container-item container-item-1">
            <h1>Reader is a place to write, read, and connect</h1>
            <h3>It's easy and free to post your thinking on any topic and connect with millions of readers.</h3>
            <a href="#">Start Writing</a>
        </div>
        <div class="container-item container-item-2">
            <img src="Shared/images/mediumi1.jpeg" />
            <ul>
                <li>Create</li>
                <li>Shape</li>
                <li>Explore</li>
                <li>Read</li>
                <li>Write</li>
                <li>Connect</li>
            </ul>
        </div>
    </main> 
    <footer>
        <div class="footer-item-1">
            <h1>Create the space for your thinking to take off.</h1>
            <p>A blank page is also a door. At <span>Reader</span> you can walk through it. It's easy and free to share your thinking on any topic, connect with an audience, express yourself with a range of publishing tools, and even earn money for your work.</p>
            <p>Read, write, and expand your world.</p>
        </div>
        <div class="footer-item-2">
            <h1>Reader</h1>
            <p>Write or read something short and sweet or long and deep, once a week or once a month.</p>
            <ol>
                <li>About</li>
                <li>Terms</li>
                <li>Privacy</li>
            </ol>
        </div>
    </footer>
    </form>
    <script>
        function redirectFunc(url)
        {
            window.location.href = url;
        }
    </script>
</body>
</html>
