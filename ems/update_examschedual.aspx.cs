using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace ems
{
    public partial class update_examschedual : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "select * from programedetail;" + "select * from semesterdetail;"+ "select * from examdetail";
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

                examnameDropDownList1.DataSource = ds.Tables[2].DefaultView;
                examnameDropDownList1.DataTextField = "examname";
                examnameDropDownList1.DataValueField = "id";
                examnameDropDownList1.DataBind();
                examnameDropDownList1.Items.Insert(0, new ListItem("Select exam"));
            }
            int id = 0;
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    id = Convert.ToInt16(Request.QueryString["id"]);

                    string query = "select * from exam_datetime_detail where id=" + id;
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            programeDropDownList1.SelectedValue = rd[1].ToString();
                            semesterDropDownList2.SelectedValue = rd[2].ToString();
                            examnameDropDownList1.SelectedValue = rd[3].ToString();
                            subjectDropDownList3.SelectedValue = rd[4].ToString();
                            exam_date.Text = (Convert.ToDateTime(rd[5]).ToString("yyyy-MM-dd")); 
                            exam_starttime.Text = rd[6].ToString();
                            exam_endtime.Text = rd[7].ToString();
                            exam_mark.Text = rd[8].ToString();                       
                        }
                    }
                }

            }
        }

        protected void semesterDropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string program = programeDropDownList1.SelectedValue;
            string sem = semesterDropDownList2.SelectedValue;

            string query = $"select * from subjectdetail where programe='{program}' and semester='{sem}'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

           

            subjectDropDownList3.DataSource = ds.Tables[1].DefaultView;
            subjectDropDownList3.DataTextField = "subject";
            subjectDropDownList3.DataValueField = "id";
            subjectDropDownList3.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

        }
    }
}