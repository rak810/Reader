<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="Reader.EditPost" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reader | Edit Article</title>
    <link href="Shared/css/WritePost.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <header>
            <h3>Reader</h3>
            <ul>
                <li>Home</li>
                <li>New Article</li>
                <li><img src="Shared/images/14.jpg" alt=""  id="profImgID" runat="server"/></li>
            </ul>
        </header> 
        <main>
            <div class="editor">
                <input type="text" name="title" id="titleInput" placeholder="Title" runat="server">
                <input type="text" name="summary" id="aboutInput" placeholder="What's this article about." runat="server">
                <textarea name="post" id="bodyInput" cols="30" rows="10" placeholder="Write your article here in markdown format." runat="server"></textarea>
                <input type="text" name="tags" id="tagInput" placeholder="Tags" runat="server">
                <button type="submit" id="postBtn" runat="server" onserverclick="postBtn_ServerClick">Submit Edit</button> 
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
