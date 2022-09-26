using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace Reader
{

    public partial class EditProfile : System.Web.UI.Page
    {
        private SqlOperations _sqlOp = new SqlOperations();

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
                var user = _sqlOp.GetUserData(uName);

                if (user.PicPath != string.Empty)
                {
                    SetPicture(user.PicPath);
                }
                name.Value = user.Name;
                email.Value = user.Email;
                if (user.Bio != null || user.Bio != string.Empty)
                {
                    bio.Value = user.Bio;
                }
                if (user.Profession != null || user.Profession != string.Empty)
                {
                    prof.Value = user.Profession;
                }


            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            if (Request["name"] == string.Empty || Request["email"] == string.Empty)
            {
                string csName = "AlertScript";
                Type csType = this.GetType();
                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsStartupScriptRegistered(csType, csName))
                {
                    StringBuilder csText = new StringBuilder();
                    csText.Append("<script type=text/javascript> alert('Name or Email Can't Be Empty!') </");
                    csText.Append("script>");

                    cs.RegisterStartupScript(csType, csName, csText.ToString());
                }
                Response.Redirect("~/Error.aspx");
            }
            else
            {
                if (!_sqlOp.IsConnectionOpen()) _sqlOp.OpenConnection();

                int a = _sqlOp.UpdateUserName(Session["userName"].ToString(), Request["name"]);
                int b = _sqlOp.UpdateUserEmail(Session["userName"].ToString(), Request["email"]);
                int c = _sqlOp.UpdateUserProfession(Session["userName"].ToString(), Request["prof"]);
                int d = _sqlOp.UpdateUserBio(Session["userName"].ToString(), Request["bio"]);
                if (!string.IsNullOrEmpty(Request["newpass"]))
                {
                    _sqlOp.UpdateUserPassword(Session["userName"].ToString(), Request["newpass"]);
                }
                HttpPostedFile pFile = Request.Files["fupload"];

                if (pFile != null && pFile.ContentLength > 0)
                {
                    string filePath = Server.MapPath("~/Shared/Assests/Images/") + Path.GetFileName(pFile.FileName);
                    pFile.SaveAs(filePath);
                    _sqlOp.UpdateUserPicture(Session["userName"].ToString(), Path.GetFileName(pFile.FileName));
                }
                _sqlOp.CloseConnection();

                Session["test"] = a.ToString() + b.ToString() + c.ToString() + d.ToString();
                Response.Redirect("~/Home.aspx");
            }

        }

        private void SetPicture(string name)
        {
            profImgID.Alt = name;
            profImgID.Src = "~/Shared/Assests/Images/" + name;
        }

        protected void logoutBtn_ServerClick(object sender, EventArgs e)
        {
            if (Request.Cookies["authCookie"] != null)
            {
                Response.Cookies["authCookie"].Expires = DateTime.Now.AddDays(-1);
                Session["isLogged"] = null;
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}