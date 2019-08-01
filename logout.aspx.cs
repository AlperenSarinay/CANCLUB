using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('çıkış yaptınız')", true);
            Session["currentuser"] = null;
            Session["Currentuser_email"] = null;
            Session["Currentuser_name"] = null;
            Session["Currentuser_surname"] = null;
            Session["currentuser_username"] = null;
            Response.Redirect("login.aspx");
       

    }
}