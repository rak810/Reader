using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reader
{
    public partial class DeletePost : System.Web.UI.Page
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
                _sqlOp.DeletePostById(Int32.Parse(Request.QueryString["pid"]));

                _sqlOp.CloseConnection();
                Response.Redirect("~/Profile.aspx");
            } 
        }
    }
}