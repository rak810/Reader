<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Reader.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About</title>
    <link href="Shared/css/About.css" rel="stylesheet" />
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
                    <h1>
                        Every idea needs a <span>Reader.</span>
                    </h1>
                </div>
                <div class="container-item container-item-2">
                    <h1>A living network of curious minds.</h1>
                    <p>
                        Anyone can write on Medium. Thought-leaders, journalists, experts, and individuals with unique perspectives share their thinking here. You’ll find pieces by independent writers from around the globe, stories we feature and leading authors, and smart takes on our own suite of blogs and publications.
                    </p>
                </div>
                <div class="container-item container-item-3">
                    <img src="Shared/images/woman-on-the-train.jpg" />
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
