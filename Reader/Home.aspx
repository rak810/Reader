<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Reader.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title id="titleId" runat="server">Reader | User</title>
    <link href="Shared/css/Home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
<header>
        <h3 onclick="redirectFunc('Home.aspx')">Reader</h3>
        <ul>
            <li onclick="redirectFunc('Profile.aspx')">Profile</li>
            <li onclick="redirectFunc('WritePost.aspx')">New Article</li>
            <li id="profileClick" runat="server"><img src="Shared/images/14.jpg" alt="" id="profImgID" runat="server"></li>
        </ul>
    </header> 
    <main>
        <div class="posts-div">
            <ul class="tabs">
                <li class="active-tab">Latest Posts</li>
            </ul>
            <div class="posts" runat="server" id="profilePostDivId">
                <div class="card">
                    <div class="img-div">
                        <img src="https://picsum.photos/seed/picsum/200/300" alt="">
                    </div>
                    <div class="card-text">
                        <h3 class="card-title">This is some negro shit</h3>
                        <p class="auth-date-p">
                            <span class="author">Notorious B.I.G</span>
                            •
                            <span class="date">20/10/2022</span>
                        </p>
                        <p class="card-summary">
                            Lorem ipsum dolor, sit amet consectetur adipisicing elit. Aperiam dolorem, aut sunt adipisci distinctio quisquam aliquam minus architecto itaque recusandae maiores deserunt accusamus temporibus tempore mollitia molestiae voluptatem ea ut?
                        </p>
                        <p class="tags">
                            <span class="tag">Rap music</span>
                            <span class="tag">Niggers</span>
                            <span class="tag">Crip</span>
                        </p>
                    </div>
                </div>
                <div class="card">
                    <div class="img-div">
                        <img src="https://picsum.photos/seed/picsum/200/300" alt="">
                    </div>
                    <div class="card-text">
                        <h3 class="card-title">This is some negro shit</h3>
                        <p class="auth-date-p">
                            <span class="author">Notorious B.I.G</span>
                            •
                            <span class="date">20/10/2022</span>
                        </p>
                        <p class="card-summary">
                            Lorem ipsum dolor, sit amet consectetur adipisicing elit. Aperiam dolorem, aut sunt adipisci distinctio quisquam aliquam minus architecto itaque recusandae maiores deserunt accusamus temporibus tempore mollitia molestiae voluptatem ea ut?
                        </p>
                        <p class="tags">
                            <span class="tag">Rap music</span>
                            <span class="tag">Niggers</span>
                            <span class="tag">Crip</span>
                        </p>
                    </div>
                </div>
                <div class="card">
                    <div class="img-div">
                        <img src="https://picsum.photos/seed/picsum/200/300" alt="">
                    </div>
                    <div class="card-text">
                        <h3 class="card-title">This is some negro shit</h3>
                        <p class="auth-date-p">
                            <span class="author">Notorious B.I.G</span>
                            •
                            <span class="date">20/10/2022</span>
                        </p>
                        <p class="card-summary">
                            Lorem ipsum dolor, sit amet consectetur adipisicing elit. Aperiam dolorem, aut sunt adipisci distinctio quisquam aliquam minus architecto itaque recusandae maiores deserunt accusamus temporibus tempore mollitia molestiae voluptatem ea ut?
                        </p>
                        <p class="tags">
                            <span class="tag">Rap music</span>
                            <span class="tag">Niggers</span>
                            <span class="tag">Crip</span>
                        </p>
                    </div>
                </div>
                <div class="card">
                    <div class="img-div">
                        <img src="https://picsum.photos/seed/picsum/200/300" alt="">
                    </div>
                    <div class="card-text">
                        <h3 class="card-title">This is some negro shit</h3>
                        <p class="auth-date-p">
                            <span class="author">Notorious B.I.G</span>
                            •
                            <span class="date">20/10/2022</span>
                        </p>
                        <p class="card-summary">
                            Lorem ipsum dolor, sit amet consectetur adipisicing elit. Aperiam dolorem, aut sunt adipisci distinctio quisquam aliquam minus architecto itaque recusandae maiores deserunt accusamus temporibus tempore mollitia molestiae voluptatem ea ut?
                        </p>
                        <p class="tags">
                            <span class="tag">Rap music</span>
                            <span class="tag">Niggers</span>
                            <span class="tag">Crip</span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </main>
    </form>

    <script>
        function redirectFunc(url) {
            window.location.href = url;
        }
        var profClick = document.querySelector('#profileClick');
            profClick.addEventListener('click', function() {
                window.location.href = "EditProfile.aspx";
            });
    </script>
</body>
</html>
