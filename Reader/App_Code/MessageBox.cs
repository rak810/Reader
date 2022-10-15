using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Reader.App_Code
{
    public static class MessageBox
    {
        public static void Show(this Page Page, String Msg)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Msg + "');</script>"
            );
        }
    }
}