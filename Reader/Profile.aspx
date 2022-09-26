<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Reader.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reader | Profile </title>
    <link href="Shared/css/Profile.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<header>
        <h3 onclick="redirectFunc('Home.aspx')">Reader</h3>
        <ul>
            <li id="proLiClick" onclick="redirectFunc('Profile.aspx')" runat="server">Profile</li>
            <li id="newLiClick" onclick="redirectFunc('WritePost.aspx')" runat="server">New Article</li>
            <li id="profileClick" runat="server"><img src="Shared/images/14.jpg" alt="" id="profImgID" runat="server"></li>
        </ul>
    </header> 
    <main>
        <input type="hidden" name="test" id="hiddenInput" runat="server">
        <div class="profile-div">
            <img src="Shared/images/14.jpg" alt="" id="imgID" runat="server">
            <h2 class="name-p" id="nameId" runat="server">Random Guy</h2>
            <p class="uname-p mb-5" id="unameId" runat="server">@nigg_10</p>
            <p class="prof-p mb-5" id="profID" runat="server">Party Goer</p>
            <p class="bio-p mb-5" id="bioID" runat="server">Hottest Nigga in the town. Imma cum in ya.</p>
            <a href="#" class="edit-btn" id="editBtn" onclick="redirectFunc('EditProfile.aspx')" runat="server">Edit Your Profile</a>
        </div>
        <div class="posts-div">
            <ul class="tabs">
                <li class="active-tab" runat="server" id="tabOne">Your Posts</li>
                <li id="tabTwo">Saved Posts</li>
            </ul>
            <div class="posts" runat="server" id="profilePostDivId">
            </div>
        </div>
    </main>
    </form>
    <script>
        function redirectFunc(url) {
            window.location.href = url;
        }

        console.log(document.querySelector('#hiddenInput').value);
        var tabOne = document.querySelector('#tabOne');
        var tabTwo = document.querySelector('#tabTwo');
        var ht = document.querySelector('.posts').innerHTML;
        tabTwo.addEventListener('click', function() {
            tabOne.classList.remove('active-tab');
            tabTwo.classList.add('active-tab');
            document.querySelector('.posts').innerHTML = document.querySelector('#hiddenInput').value;
        });

        tabOne.addEventListener('click', function() {
            tabTwo.classList.remove('active-tab');
            tabOne.classList.add('active-tab');
            document.querySelector('.posts').innerHTML = ht;
        });
    </script>
</body>
</html>
