using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Profil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["currentuser"] != null)
        {
            if (!IsPostBack)
            {
                LinkButton lbMasterProfil = new LinkButton();
                lbMasterProfil = (LinkButton)Master.FindControl("LinkButtonProfil");

                LinkButton lbMasterActivities = new LinkButton();
                lbMasterActivities = (LinkButton)Master.FindControl("LinkButtonActivities");

                LinkButton lbMasterAddActivity = new LinkButton();
                lbMasterAddActivity = (LinkButton)Master.FindControl("LinkButtonAddActivity");

                LinkButton lbMasterLogout = new LinkButton();
                lbMasterLogout = (LinkButton)Master.FindControl("LinkButtonLogout");

                LinkButton lbMasterLike = new LinkButton();
                lbMasterLike = (LinkButton)Master.FindControl("LinkButtonLike");

                LinkButton lbMasterHomePage = new LinkButton();
                lbMasterHomePage = (LinkButton)Master.FindControl("LinkButtonHomePage");

                LinkButton lbMasterBestActivity = new LinkButton();
                lbMasterBestActivity = (LinkButton)Master.FindControl("LinkButtonBestActivity");

                lbMasterProfil.Visible = true;
                lbMasterLogout.Visible = true;
                lbMasterLike.Visible = true;
                lbMasterHomePage.Visible = true;
                lbMasterBestActivity.Visible = true;
                lbMasterAddActivity.Visible = true;
                lbMasterActivities.Visible = true;



                Label lblWelcome = new Label();
                lblWelcome = (Label)Master.FindControl("LabelWelcome");
                lblWelcome.Text = Session["Currentuser_name"].ToString() + ' ' + Session["Currentuser_surname"].ToString();
                lblWelcome.Visible = true;

                if (Convert.ToInt32(Session["currentuser_rol"]) == 1)
                {
                    LinkButton lbMasterAdmin = new LinkButton();
                    lbMasterAdmin = (LinkButton)Master.FindControl("LinkButtonAdmin");
                    lbMasterAdmin.Visible = true;

                }
            }
            using (var myDB = new webDbEntities())
            {
                var A_mail = Session["Currentuser_email"].ToString();
                if (!IsPostBack)
                {
                    
                    
                    var loggeduser = (from u in myDB.user
                                      where u.email == A_mail
                                      select u).FirstOrDefault();
                    if(loggeduser != null)
                    {
                        TextBoxFname.Text = loggeduser.name;
                        TextBoxLastName.Text = loggeduser.surname;
                        TextBoxEmail.Text = loggeduser.email;
                        TextBoxDepartment.Text = loggeduser.department;
                        TextBoxUserName.Text = loggeduser.username;
                        ProfilResmi.ImageUrl = Session["ImagePath"].ToString();
                    }
                   
                }
            }
                
            
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        using (var myDB = new webDbEntities())
        {
            int loggeduserid = Convert.ToInt32(Session["currentuser"]);
            var loggeduser = (from u in myDB.user
                              where u.id == loggeduserid
                              select u).FirstOrDefault();

            if(loggeduser != null)
            {
                user newuser = (user)loggeduser;
                newuser.name = TextBoxFname.Text;
                newuser.surname = TextBoxLastName.Text;
                newuser.username = TextBoxUserName.Text;
                newuser.email = TextBoxEmail.Text;
                newuser.department = TextBoxDepartment.Text;
                newuser.password = TextBoxPass.Text;
                if (this.fluDosya.HasFile)
                {
                    fluDosya.SaveAs(Server.MapPath("~/Resimler/" + this.fluDosya.FileName));
                    string fileName = Path.GetFileName(this.fluDosya.PostedFile.FileName);
                    Session["ImagePath"] = "Resimler/" + fileName;

                    newuser.photo = Convert.ToString(Session["ImagePath"]);
                }
                myDB.SaveChanges();
                Response.Redirect("Profil");
            }
        }
           




    }
}