using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Like : System.Web.UI.Page
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
                lblWelcome.Text = Session["Currentuser_name"].ToString() + ' ' + Session["Currentuser_surname"].ToString();
                lblWelcome.Visible = true;

                if (Convert.ToInt32(Session["currentuser_rol"]) == 1)
                {
                    LinkButton lbMasterAdmin = new LinkButton();
                    lbMasterAdmin = (LinkButton)Master.FindControl("LinkButtonAdmin");
                    lbMasterAdmin.Visible = true;

                }
            }
            if (!Page.IsPostBack)
            {
                if (Session["Currentuser_email"] != null)
                {


                    using (var myDB = new webDbEntities())
                    {
                        var allact = (from u in myDB.activity
                                      select u).ToList();
                        DateTime currentdate = Convert.ToDateTime(DateTime.Now);
                        foreach (var x in allact.ToList())
                        {
                            DateTime dob = Convert.ToDateTime(x.date);
                            TimeSpan time = currentdate.Subtract(dob);
                            int control = time.Days;
                            if (control > 15)
                            {
                                allact.Remove(x);
                            }

                        }


                        GridView1.DataSource = allact;
                        GridView1.DataBind();

                    }
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

        foreach (GridViewRow row in GridView1.Rows)
        {

            RadioButtonList status = (row.Cells[6].FindControl("RadioButtonList1") as RadioButtonList);
            if (status.SelectedItem != null)
            {
                string value = status.SelectedItem.Text;


                Label tbx = row.Cells[0].FindControl("Id") as Label;
                int u_id = Convert.ToInt32(tbx.Text);

                if (value == "Like")
                {
                    updaterow(u_id, 1);
                }

                else if (value == "Disslike")
                {
                    updaterow(u_id, 0);
                }
            }
            
        }
        Response.Redirect("Like");
    }
    private void updaterow(int rollno, int markstatus)
    {
        using (var myDB = new webDbEntities())
        {
            int loggeduserid = Convert.ToInt32(Session["currentuser"]);
            int activityid = rollno;
            var loggeduser = (from u in myDB.like where u.user_id == loggeduserid && u.activity_id == activityid select u).FirstOrDefault();
            if (loggeduser != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Daha önce like veya dislike vermişsiniz. Like veya dislike verdiğiniz değerler değişmedi.')", true);
            }
            else
            {
                string loggedusername = Session["currentuser_username"].ToString();

                var likeekle = (from u in myDB.user where u.username == loggedusername select u).FirstOrDefault();
                if (likeekle != null)
                {
                    var newlike = new like();
                    newlike.activity_id = rollno;
                    newlike.user_id = loggeduserid;
                    if (markstatus == 1)
                    {
                        newlike.total = Convert.ToInt32(markstatus);
                        myDB.like.Add(newlike);
                        myDB.SaveChanges();
                    }
                    else
                    {
                        newlike.min = 1;
                        myDB.like.Add(newlike);
                        myDB.SaveChanges();
                    }



                    activity act = (from u in myDB.activity where u.id == newlike.activity_id select u).FirstOrDefault();
                    if (newlike.total == 1)
                    {
                        act.TotalLike++;
                        act.score++;

                    }
                    else
                    {
                        act.TotalDislike++;
                        act.score--;
                    }

                    myDB.SaveChanges();
                    
                    
                }
            }
        }



    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
