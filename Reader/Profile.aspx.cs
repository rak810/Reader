using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reader
{
    public partial class Profile : System.Web.UI.Page
    {
        private SqlOperations _sqlOp = new SqlOperations();
        protected void Page_Load(object sender, EventArgs e)
        {
            string uName;
            if (Session["isLogged"] != null)
            {
                uName = Session["userName"].ToString();
                profileClick.Attributes.Add("online", "redirectFunc('EditProfile.aspx')");
            }
            else
            {
                uName = Request.QueryString["u"].ToString();
                string str = string.Format("redirectFunc('Profile.aspx?u={0}')", uName);
                profileClick.Attributes.Add("online", str);
                editBtn.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                newLiClick.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                proLiClick.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }

            if (_sqlOp.IsConnectionOpen())
            {
                _sqlOp.CloseConnection();
            }
            _sqlOp.OpenConnection();

            try
            {
                var user = _sqlOp.GetUserData(uName);
                if (user.PicPath != string.Empty)
                {
                    SetPicture(user.PicPath);
                    imgID.Src = "~/Shared/Assests/Images/" + user.PicPath;
                }

                _sqlOp.CloseConnection();
                _sqlOp.OpenConnection();

                List<Article> aList = _sqlOp.GetArticlesByAuthor(user.Id);

                _sqlOp.CloseConnection();

                _sqlOp.OpenConnection();
                List<Article> savedArticles = _sqlOp.GetSavedArticlesByUser(user.Id);
                _sqlOp.CloseConnection();

                nameId.InnerText = user.Name;
                unameId.InnerText = user.UserName;
                bioID.InnerText = user.Bio;
                profID.InnerText = user.Profession;
                profilePostDivId.InnerHtml = RenderArticles(aList, user.Name);
                hiddenInput.Value = RenderSavedArticles(savedArticles);
            }
            catch (InvalidOperationException err)
            {
                Response.Write(err.Message);
            }
        }

        private string RenderSavedArticles(List<Article> aList)
        {
            _sqlOp.OpenConnection();
            List<Tuple<int, string>> userList = _sqlOp.GetUsersNameId();
            _sqlOp.CloseConnection();

            StringBuilder st = new StringBuilder();
            foreach (Article article in aList)
            {
                StringBuilder stb = new StringBuilder();
                stb.Append("<div class=\"card\">");
                stb.Append("<div class=\"card-text\">");
                stb.AppendFormat("<h3 class=\"card-title\" onclick=\"redirectFunc('Post.aspx?u={0}&pid={1}')\">{2}</h3>", article.AuthorId, article.Id, article.Title);
                stb.Append("<p class=\"auth-date-p\">");
                stb.AppendFormat("<span class=\"author\">{0}</span> •", GetNameById(userList, article.AuthorId));
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

            return st.ToString();
        }

        private string GetNameById(List<Tuple<int, string>> tList, int uid)
        {
            string name = string.Empty;

            foreach (var item in tList)
            {
                if (item.Item1 == uid)
                {
                    name = item.Item2;
                    break;
                }
            }

            return name;
        }
        private string RenderArticles(List<Article> aList, string name)
        {
            StringBuilder st = new StringBuilder();


            foreach (Article article in aList)
            {
                StringBuilder stb = new StringBuilder();
                stb.Append("<div class=\"card\">");
                stb.Append("<div class=\"card-text\">");
                stb.AppendFormat("<h3 class=\"card-title\" onclick=\"redirectFunc('Post.aspx?u={0}&pid={1}')\">{2}</h3>", article.AuthorId, article.Id, article.Title);
                stb.Append("<p class=\"auth-date-p\">");
                stb.AppendFormat("<span class=\"author\">{0}</span> •", name);
                stb.AppendFormat(" <span class=\"date\">{0}</span>", article.PublishedAt.ToLongDateString());     
                stb.Append("</p>");           
                stb.AppendFormat("<p class=\"card-summary\">{0}</p>", article.Summary); 
                stb.Append("<p class=\"tags\">"); 
                stb.Append(ProcessTags(article.Tags));        
                stb.Append("</p>");
                if (Session["isLogged"] != null)
                {
                    stb.Append("<p class=\"operations\">");
                    stb.AppendFormat("<span onclick=\"redirectFunc('EditPost.aspx?u={0}&pid={1}')\" id=\"edit\">Edit</span>", article.AuthorId, article.Id);
                    stb.AppendFormat("<span onclick=\"redirectFunc('DeletePost.aspx?u={0}&pid={1}')\" id=\"delete\">Delete</span>", article.AuthorId, article.Id);
                    stb.Append("</p>");
                }
                stb.Append("</div>");
                stb.Append("</div>");
                st.Append(stb.ToString());
            }

            return st.ToString();
        }

        private void SetPicture(string name)
        {
            profImgID.Alt = name;
            profImgID.Src = "~/Shared/Assests/Images/" + name;
        }

        private string ProcessTags(string tags)
        {
            var tagList = tags.Split(',');
            StringBuilder stBuilder = new StringBuilder();
            foreach(var tag in tagList)
            {
                string str = string.Format("<span class=\"tag\">{0}</span>", tag);
                stBuilder.Append(str);
            }
            
            return stBuilder.ToString();
        }
    }
}