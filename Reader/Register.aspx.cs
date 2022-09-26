using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Reader
{
    public partial class Register : System.Web.UI.Page
    {
        private SqlOperations _sqlOp = new SqlOperations();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_sqlOp.IsConnectionOpen())
            {
                _sqlOp.CloseConnection();
            }

            _sqlOp.OpenConnection();
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {

            if (_sqlOp.DoesUserExist(username.Value, email.Value))
            {
                Response.Write("<script>alert('Username or Email already exists!');</script>");
                username.Value = string.Empty;
                email.Value = string.Empty;
            }
            else
            {

                try
                {
                    _sqlOp.CreateUser(name.Value, username.Value, email.Value, pass.Value);
                    Session["isLogged"] = true;
                    Session["userName"] = username.Value;
                    Response.Redirect("~/EditProfile.aspx");
                }
                catch (SqlException err)
                {
                    Response.Write("<script>alert('Sql Error: " + err.Message + ";');</script>");
                }
            }
        }
    }
}