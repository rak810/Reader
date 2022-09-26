using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reader
{
    public partial class Signin : System.Web.UI.Page
    {
        private SqlOperations _sqlOp = new SqlOperations();
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies["authCookie"];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                Session["isLogged"] = true;
                Session["userName"] = Request.Cookies["authCookie"]["uname"].ToString();
                Response.Redirect("~/Home.aspx");
            }
            if (_sqlOp.IsConnectionOpen())
            {
                _sqlOp.CloseConnection();
            }

            _sqlOp.OpenConnection();

        }

        protected void btn_ServerClick(object sender, EventArgs e)
        {
            string res = _sqlOp.GetUserPassword(username.Value);
            if (pass.Value.Equals(res)) 
            {
                HttpCookie authCookie = new HttpCookie("authCookie");
                authCookie["uname"] = username.Value;
                authCookie["res"] = res;
                authCookie.Expires = DateTime.Now.AddMinutes(10);
                Response.Cookies.Add(authCookie);
                Session["isLogged"] = true;
                Session["userName"] = username.Value;
                Response.Redirect("~/Home.aspx");
            }
        }
    }
}