<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="Reader.Posts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reader | Article</title>
    <link href="Shared/css/Post.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>
                <h3>Reader</h3>
                <ul onclick="redirectFunc('Profile.aspx')">
                    <li>John Doe</li>
                    <li>
                        <img src="Shared/images/14.jpg" class="imgClass" id="imgIdUlDiv" runat="server" /></li>
                </ul>
            </header>
            <main>
                <h1 class="post-title" id="titleId" runat="server">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptatibus numquam, incidunt
                    consequatur, quae.</h1>
                <div>
                    <p class="author"> <span class="img-span"> <img src="Shared/images/14.jpg" class="imgClass" id="imgIdAuthorDiv" runat="server"/></span> <span id="authorSpanId" runat="server">This is a very long ass
                        name</span><span class="follow-span" runat="server" id="followId">follow</span></p>
                    <p>
                        <span class="date-span"><span id="dateSpan" runat="server">23 Nov, 2021</span> · </span>
                        <span class="time-span"> <span id="timeSpan"></span> mins read</span>
                    </p>
                    <p class="svg-p">
                         <a href="#"  id="savePostClick" onserverclick="savePostClick_ServerClick" runat="server">
		                    <span>
                                <img src="Shared/images/link.svg" alt="">
                                Save Post
                            </span>
		                </a>
                        <span onclick="copyLink();">
                            <img src="Shared/images/link.svg" alt="">
                            Copy Link
                        </span>
                    </p>
                </div>
                <div class="post-body" id="postBodyId" runat="server">
                    
                </div>
            </main>
            <div class="info-div">
                <div class="tag-div" id="tagDivId" runat="server">
                    <a href="">React</a>
                    <a href="">Javascript</a>
                    <a href="">Programming</a>
                    <a href="">Node.js</a>
                    <a href="">Clean Code</a>
                </div>
                <div class="post-info-div">
                    <button id="likeBtnId"><img src="Shared/images/clap.svg" alt="claps"> <span class="clap-value" id="likeValueId" runat="server">20</span></button>
                    <button id="commBtnId"  runat="server"><img src="Shared/images/comment.svg" alt="comments"> <span class="comm-value" id="commCountId" runat="server">20</span></button>
                    <img src="Shared/images/link.svg" alt="" onclick="copyLink();">
                    <img src="Shared/images/save.svg" alt="" runat="server">
                </div>
            </div>
            <footer>
                <div class="author-div">
                    <p class="author"> 
                        <span class="img-span"> <img src="Shared/images/14.jpg" class="imgClass" id="imgIdAuthorSpanDiv" runat="server" alt=""> </span>
                        <span id="nameSpanAuthorDiv" runat="server"></span>
                        <span class="follow-span">follow</span>
                    </p>
                    <p>Read More from this author.</p> 
                </div>
                <div class="posts-div" id="postsDivId" runat="server">
                </div>
                <div class="footer-div">
                    <h3>Reader</h3>
                </div>
            </footer>
    </form>

    <script>

        function copyLink() {

            navigator.clipboard.writeText(window.location.href).then(function () {
                console.log('Async: Copying to clipboard was successful!');
            }, function (err) {
                console.error('Async: Could not copy text: ', err);
            });
        }
        function readingTime() {
          var text = document.getElementById("postBodyId").innerText;
          var wpm = 225;
          var words = text.trim().split(/\s+/).length;
          var time = Math.ceil(words / wpm);
          document.getElementById("timeSpan").innerText = time;
        }

        readingTime();

        function redirectFunc(url) {
            window.location.href = url;
        }

        var likeSpan = document.querySelector('#likeValueId');
        var likeCount = parseInt(likeSpan.innerText);
        var likeState = false;
        var urlParams = new URLSearchParams(window.location.search);
        var myParam = urlParams.get('pid');

        document.querySelector("likeBtnId").addEventListener('click', function (e) {
            console.log("Liked");
            e.preventDefault();
        })

    </script>
</body>
</html>
