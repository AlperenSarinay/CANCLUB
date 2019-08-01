using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
                              where u.email == TextBoxEmail.Text
                              select u).FirstOrDefault();
            if (loggeduser != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Bu mail adresi kullanılıyor.')", true);
            }
            else
            {
                user newuser = new user();
                newuser.name = TextBoxFname.Text;
                newuser.surname = TextBoxLastName.Text;
                newuser.username = TextBoxUserName.Text;
                newuser.email = TextBoxEmail.Text;
                newuser.birthdate = Convert.ToDateTime(TextBoxBirthDate.Text);
                newuser.department = TextBoxDepartment.Text;
                newuser.password = TextBoxPass.Text;
                newuser.rol = 0;

                if (this.fluDosya.HasFile)
                {
                    fluDosya.SaveAs(Server.MapPath("~/Resimler/" + this.fluDosya.FileName));
                    string fileName = Path.GetFileName(this.fluDosya.PostedFile.FileName);
                    Session["ImagePath"] = "Resimler/" + fileName;

                    newuser.photo = Convert.ToString(Session["ImagePath"]);
                }
                myDB.user.Add(newuser);
                myDB.SaveChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), " ", "alert('Sign up Successful!')", true);
            }

        }
    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
}