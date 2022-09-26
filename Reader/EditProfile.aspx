<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="Reader.EditProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Shared/css/edit-profile.css" rel="stylesheet" />
    <title>Reader | Edit Profile</title>
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <h3>Reader</h3>
        <ul>
            <li><a href="#" runat="server" id="logoutBtn" onserverclick="logoutBtn_ServerClick" class="logout">Logout</a></li>
            <li onclick="redirectFunc('Profile.aspx')">Profile</li>
            <li onclick="redirectFunc('WritePost.aspx')">New Article</li>
            <li><img src="Shared/images/14.jpg" alt="" id="profImgID" runat="server"></li>
        </ul>
    </header>
    <h1>Edit Profile</h1>
    <main>
        <div id="edit">
            <input type="text" name="name" id="name" placeholder="Your Name" runat="server">
            <input type="email" name="email" id="email" placeholder="Your Email" runat="server">
            <input type="text" name="prof" id="prof" placeholder="Your Profession" runat="server">
            <input type="password" name="newpass" id="newpass" placeholder="New Password" runat="server"> 
            <textarea name="bio" id="bio" cols="30" rows="10" placeholder="Your bio in 150 characters..." runat="server"></textarea>
            <input type="file" name="fupload" id="fupload" accept="image/png, image/jpeg" hidden runat="server">
            <label for="fupload">Choose A Profile Picture</label>
            <asp:button OnClick="updateBtn_Click" text="Update" runat="server" ID="updateBtn" />          
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
