<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Reader.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reader | Register </title>
    <link href="Shared/css/Register.css" rel="stylesheet" />
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
        <h1>Sign Up</h1>
        <main class="main">
            <div>
                <input type="text" name="name" id="name" placeholder="Your Name" runat="server">
                <input type="email" name="email" id="email" placeholder="Your Email" runat="server">
                <input type="text" name="username" id="username" placeholder="Your Username" runat="server">
                <input type="password" name="pass" id="pass" placeholder="Your Password" runat="server">
                <label id="passLabel"></label>
                <input type="password" name="re-pass" id="repass" placeholder="Retype your password" runat="server">   
                <asp:Button Text="Register" runat="server" ID="registerBtn" OnClick="registerBtn_Click"/>   
            </div>
        </main>  
    </form>
        <script>
            document.querySelector('.main div').style.height = '350px';
            document.querySelector('h1').style.top= '28%';
            passLabel.style.display = 'none';
            var pass = document.querySelector('#pass');
            var repass = document.querySelector('#repass');
            var pLabel = document.querySelector('#passLabel');
            pass.addEventListener('keyup', function (e) {
                if (pass.value.length < 6 && pass.value.length >= 1) {
                    passLabel.style.display = 'block';
                    passLabel.innerText = 'Password length is smaller than 6 digits.'
                }
                else {
                    passLabel.style.display = 'none';
                }
            });

            repass.addEventListener('keyup', function (e) {
                if (pass.value !== repass.value) {
                    passLabel.style.display = 'block';
                    passLabel.innerText = 'Passwords do not match.'
                }
                else {
                    passLabel.style.display = 'none';
                }
            });
    </script>
</body>
</html>
