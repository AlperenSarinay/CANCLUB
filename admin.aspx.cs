using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["currentuser"] != null && Convert.ToInt32(Session["currentuser_rol"]) == 1)
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
        }
        else
        {
            Response.Redirect("HomePage.aspx");
        }
    }
    protected void DeleteUser(object sender, GridViewDeleteEventArgs e)
    {
        int r = Convert.ToInt32(e.RowIndex.ToString());
        int butonubul = int.Parse(GridView1.DataKeys[r].Value.ToString());
        int kullanıcı = Convert.ToInt32(Session["currentuser"]);
        if (butonubul == kullanıcı)
        {
            Response.Redirect("admin");
        }
        else
        {
        using (var db = new webDbEntities())
        {
            user users = db.user.Where(x => x.id == butonubul).FirstOrDefault();

            List<activity> aktivite_listesi = (from u in db.activity
                                               where u.activity_by == butonubul
                                               select u).ToList();
           

            foreach (var Item in aktivite_listesi)
            {
                List<like> L_list = (from u in db.like
                                     where Item.id == u.activity_id
                                     select u).ToList();

                foreach (var i in L_list)
                {
                    db.like.Remove(i);
                }
                List<comments> C_list = (from u in db.comments
                                         where Item.id == u.activity_id
                                         select u).ToList();
                foreach (var x in C_list)
                {
                    db.comments.Remove(x);
                }
            }
            db.SaveChanges();
            List<like> likes_listesi = (from u in db.like
                                        where butonubul == u.user_id
                                        select u).ToList();
            List<comments> comment_listesi = (from u in db.comments
                                              where butonubul == u.user_id
                                              select u).ToList();

            foreach (var x in likes_listesi)
            {
                db.like.Remove(x);

            }
            db.SaveChanges();
            foreach (var y in comment_listesi)
            {
                db.comments.Remove(y);


            }
            db.SaveChanges();
            foreach (var Item in aktivite_listesi)
            {
                db.activity.Remove(Item);
                db.SaveChanges();

            }
            db.user.Remove(users);
            db.SaveChanges();

        }
    }
    }
}
