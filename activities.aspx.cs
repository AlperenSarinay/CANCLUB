using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class activities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["currentuser"] != null)
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
                lblWelcome.Text =Session["Currentuser_name"].ToString() + ' ' + Session["Currentuser_surname"].ToString();
                lblWelcome.Visible = true;

                if (Convert.ToInt32(Session["currentuser_rol"]) == 1)
                {
                    LinkButton lbMasterAdmin = new LinkButton();
                    lbMasterAdmin = (LinkButton)Master.FindControl("LinkButtonAdmin");
                    lbMasterAdmin.Visible = true;

                }
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        using (var myDB = new webDbEntities())
        {
            int userid = Convert.ToInt32(Session["currentuser"]);
            var loggeduser = (from u in myDB.user
                              where u.id == userid
                              select u).FirstOrDefault();

            var Kontrol = (from u in myDB.activity where u.title == DropDownList1.Text select u).FirstOrDefault();
            if (loggeduser != null)
            {
                var comment = new comments();
                comment.activity_id = Convert.ToInt16(Kontrol.id);
                comment.user_id = userid;
                comment.comment_text = TextBox1.Text;
                myDB.comments.Add(comment);
                myDB.SaveChanges();
                Response.Redirect("activities.aspx");
            }
        }
        

    }
}