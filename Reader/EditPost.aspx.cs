using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reader
{
    public partial class EditPost : System.Web.UI.Page
    {
        private SqlOperations _sqlOp = new SqlOperations();
        private User user = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_sqlOp.IsConnectionOpen())
            {
                _sqlOp.CloseConnection();
            }

            _sqlOp.OpenConnection();

            if ((bool)Session["isLogged"])
            {
                string uName = Session["userName"].ToString();
                user = _sqlOp.GetUserData(uName);
                _sqlOp.OpenConnection();
                Article article = _sqlOp.GetArticleById(Int32.Parse(Request.QueryString["pid"]));
                _sqlOp.CloseConnection();
                titleInput.Value = article.Title;
                aboutInput.Value = article.Summary;
                bodyInput.Value = article.Body;
                tagInput.Value = article.Tags;

                if (user.PicPath != string.Empty)
                {
                    SetPicture(user.PicPath);
                }
            }

        }

        protected void postBtn_ServerClick(object sender, EventArgs e)
        {
            if (!_sqlOp.IsConnectionOpen()) _sqlOp.OpenConnection();

            string title = Request["titleInput"];
            string summary = Request["aboutInput"];
            string body = Request["bodyInput"];
            string tags = Request["tagInput"];

            int res = _sqlOp.EditPost(Int32.Parse(Request.QueryString["pid"]), title, summary, body, tags);

            if (res < 1) Response.Redirect("~/Error.aspx");
            else
            {
                Article article = _sqlOp.GetArticleByTitleAndAuthor(title, user.Id);
                Response.Redirect("~/Post.aspx?u=" + user.Id + "&pid=" + article.Id);
            }
            _sqlOp.CloseConnection();
        }

        private void SetPicture(string name)
        {
            profImgID.Alt = name;
            profImgID.Src = "~/Shared/Assests/Images/" + name;
        }
    }
}