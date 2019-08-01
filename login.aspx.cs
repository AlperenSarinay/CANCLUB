using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            LinkButton lbMasterlogin = new LinkButton();
            lbMasterlogin = (LinkButton)Master.FindControl("LinkButtonLogin");

            LinkButton lbMasterRegister = new LinkButton();
            lbMasterRegister = (LinkButton)Master.FindControl("LinkButtonRegister");

            lbMasterlogin.Visible = true;
            lbMasterRegister.Visible = true;
        }
    }
    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        using (var myDB = new webDbEntities())
        {
            var loggeduser = (from u in myDB.user
                              where u.email == TextBoxEmail.Text && u.password == TextBoxPass.Text
                              select u).FirstOrDefault();
            if (loggeduser != null)
            {
                Session["currentuser"] = loggeduser.id;
                Session["currentuser_rol"] = loggeduser.rol;
                Session["Currentuser_email"] = loggeduser.email;
                Session["Currentuser_name"] = loggeduser.name;
                Session["Currentuser_surname"] = loggeduser.surname;
                Session["currentuser_username"] = loggeduser.username;
                Session["ImagePath"] = loggeduser.photo;
                Response.Redirect("HomePage.aspx");
                
            }
            else
            {
                FailureText.Text = "Invalid username or password.";
                ErrorMessage.Visible = true;
            }

        }
    }

   }