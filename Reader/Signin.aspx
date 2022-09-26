<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="Reader.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reader | Sign In</title>
    <link href="Shared/css/Signin.css" rel="stylesheet" />
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
        <h1>Sign In</h1>
        <main class="main">
            <div>
                <input type="text" name="username" id="username" placeholder="Your Username" runat="server">
                <input type="password" name="pass" id="pass" placeholder="Your Password" runat="server">
                <input type="button" id="btn" value="Sign In" onserverclick="btn_ServerClick" runat="server">            
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
