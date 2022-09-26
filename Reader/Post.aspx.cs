using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reader
{
    public partial class Posts : System.Web.UI.Page
    {
        private SqlOperations _sqlOp = new SqlOperations();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (_sqlOp.IsConnectionOpen())
            {
                _sqlOp.CloseConnection();
            }

            _sqlOp.OpenConnection();

            Article article = _sqlOp.GetArticleById(Int32.Parse(Request.QueryString["pid"]));
            _sqlOp.CloseConnection();

            _sqlOp.OpenConnection();
            string authorName = _sqlOp.GetAuthorNameById(article.AuthorId);
            titleId.InnerText = article.Title;
            authorSpanId.InnerText = authorName;
            string output = CommonMark.CommonMarkConverter.Convert(article.Body);
            postBodyId.InnerHtml = output;
            ProcessTags(article.Tags);
            authorSpanId.InnerText = authorName;
            nameSpanAuthorDiv.InnerText = authorName;
            string picName = _sqlOp.GetPicNameById(article.AuthorId);
            imgIdUlDiv.Src = "~/Shared/Assests/Images/" + picName;
            imgIdAuthorDiv.Src = "~/Shared/Assests/Images/" + picName;
            imgIdAuthorSpanDiv.Src = "~/Shared/Assests/Images/" + picName; 
            dateSpan.InnerText = article.PublishedAt.ToLongDateString();
            likeValueId.InnerText = article.Likes.ToString(); 
            _sqlOp.CloseConnection();
            _sqlOp.OpenConnection();
            List<Article> aList = _sqlOp.GetArticlesTopArticlesByAuthor(article.AuthorId);
            _sqlOp.CloseConnection();
            ProcessPostsDiv(aList);

        }

        protected void ProcessPostsDiv(List<Article> aList)
        {
            StringBuilder posts = new StringBuilder();
            foreach (Article article in aList)
            {
                StringBuilder st = new StringBuilder();
                st.Append("<div class=\"post-div\">");
                st.AppendFormat("<p>{0}</p>", article.PublishedAt.ToLongDateString());
                st.AppendFormat("<h3 onclick=\"redirectFunc('Post.aspx?u={0}&pid={1}')\">{2}</h3>", article.AuthorId, article.Id, article.Title);
                st.AppendFormat("<p>{0}</p>", article.Summary);
                st.Append("</div>");
                posts.Append(st.ToString());
            }
            postsDivId.InnerHtml = posts.ToString();
        }

        protected void ProcessTags(string tags)
        {
            var tagList = tags.Split(',');
            StringBuilder stBuilder = new StringBuilder();
            foreach(var tag in tagList)
            {
                string str = string.Format("<a>{0}</a>", tag);
                stBuilder.Append(str);
            }
            tagDivId.InnerHtml = stBuilder.ToString();
        }

        protected void savePostClick_ServerClick(object sender, EventArgs e)
        {
            if (Session["isLogged"] != null)
            {
                _sqlOp.OpenConnection();
                _sqlOp.SaveArticleToUser(Int32.Parse(Request.QueryString["pid"]), Int32.Parse(Request.QueryString["u"]));
                _sqlOp.CloseConnection();
            }

        }

    }
}