using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Reader
{
    public partial class Utility : System.Web.UI.Page
    {
        private SqlOperations _sqlOp = new SqlOperations();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!_sqlOp.IsConnectionOpen()) _sqlOp.OpenConnection();

            _sqlOp.SetLikesByPostId(Int32.Parse(Request.QueryString["lc"]), Int32.Parse(Request.QueryString["pid"]));

            _sqlOp.CloseConnection();
        }
    }
}