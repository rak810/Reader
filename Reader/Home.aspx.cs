using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reader
{
    public partial class Home : System.Web.UI.Page
    {
        private SqlOperations _sqlOp = new SqlOperations();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["isLogged"])
            {
                if (_sqlOp.IsConnectionOpen())
                {
                    _sqlOp.CloseConnection();
                }
                _sqlOp.OpenConnection();

                string uName = Session["userName"].ToString();

                try
                {
                    var user = _sqlOp.GetUserData(uName);
                    _sqlOp.CloseConnection();
                    if (user.PicPath != string.Empty)
                    {
                        SetPicture(user.PicPath);
                    }

                    _sqlOp.OpenConnection();

                    List<Article> aList = _sqlOp.GetLatestArticles();

                    _sqlOp.CloseConnection();
                    RenderArticles(aList);
                }
                catch (InvalidOperationException err)
                {
                    Response.Write(err.Message);
                }
            }
            else
            {
                Response.Redirect("~/Error.aspx");
            }
        }

        private void SetPicture(string name)
        {
            profImgID.Alt = name;
            profImgID.Src = "~/Shared/Assests/Images/" + name;
        }

        private void RenderArticles(List<Article> aList)
        {
            StringBuilder st = new StringBuilder();

            _sqlOp.OpenConnection();
            foreach (Article article in aList)
            {
                StringBuilder stb = new StringBuilder();
                stb.Append("<div class=\"card\">");
                stb.Append("<div class=\"card-text\">");
                stb.AppendFormat("<h3 class=\"card-title\" onclick=\"redirectFunc('Post.aspx?u={0}&pid={1}')\">{2}</h3>", article.AuthorId, article.Id, article.Title);
                stb.Append("<p class=\"auth-date-p\">");
                stb.AppendFormat("<span class=\"author\">{0}</span> •", _sqlOp.GetAuthorNameById(article.AuthorId));
                stb.AppendFormat(" <span class=\"date\">{0}</span>", article.PublishedAt.ToLongDateString());
                stb.Append("</p>");
                stb.AppendFormat("<p class=\"card-summary\">{0}</p>", article.Summary);
                stb.Append("<p class=\"tags\">");
                stb.Append(ProcessTags(article.Tags));
                stb.Append("</p>");
                stb.Append("</div>");
                stb.Append("</div>");
                st.Append(stb.ToString());
            }

            profilePostDivId.InnerHtml = st.ToString();
            _sqlOp.CloseConnection();
        }

        private string ProcessTags(string tags)
        {
            var tagList = tags.Split(',');
            StringBuilder stBuilder = new StringBuilder();
            foreach (var tag in tagList)
            {
                string str = string.Format("<span class=\"tag\">{0}</span>", tag);
                stBuilder.Append(str);
            }

            return stBuilder.ToString();
        }
    }
}