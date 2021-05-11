using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ems
{
    public partial class update_subject : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select * from programedetail;" + "select * from semesterdetail";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                programeDropDownList1.DataSource = ds.Tables[0].DefaultView;
                programeDropDownList1.DataTextField = "programe";
                programeDropDownList1.DataValueField = "id";
                programeDropDownList1.DataBind();
                programeDropDownList1.Items.Insert(0, new ListItem("Select Programe"));

                semesterDropDownList2.DataSource = ds.Tables[1].DefaultView;
                semesterDropDownList2.DataTextField = "semester";
                semesterDropDownList2.DataValueField = "id";
                semesterDropDownList2.DataBind();
                semesterDropDownList2.Items.Insert(0, new ListItem("Select Semester"));
            }

            int id = 0;
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    id = Convert.ToInt16(Request.QueryString["id"]);

                    string query = "select * from subjectdetail where id=" + id;
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            subject.Text = rd[1].ToString();
                            subjectcode.Text = rd[2].ToString();
                            programeDropDownList1.SelectedValue = rd[3].ToString();
                            semesterDropDownList2.SelectedValue = rd[4].ToString();

                        }
                    }
                }

            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                id = Convert.ToInt16(Request.QueryString["id"]);
                con.Open();
                string qurey = "UPDATE  subjectdetail SET subject='" +subject.Text+ "', subjectcode='" + subjectcode.Text + "',programe='" + programeDropDownList1.SelectedValue + "', semester='" + semesterDropDownList2.SelectedValue + "'WHERE id='" + id + "'";
                SqlCommand cmd = new SqlCommand(qurey, con);

                cmd.ExecuteNonQuery();

                Response.Redirect("manage_subject.aspx");

            }
        }
    }
}