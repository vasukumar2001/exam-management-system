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
    public partial class exam : System.Web.UI.Page
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
        }

        protected void exam_starttime_TextChanged(object sender, EventArgs e)
        {

        }

        protected void exam_mark_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource3_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                string qurey = "insert into exam_datetime_detail(programe,semester,examname,subject,examdate,exam_start_time,exam_end_time,exam_mark) values(@programe,@semester,@examname,@subject,@examdate,@examstarttime,@examendtime,@markofexam)";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@programe", programeDropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@semester", semesterDropDownList2.SelectedValue);
                cmd.Parameters.AddWithValue("@examname", examnameDropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@subject", subjectDropDownList3.SelectedValue);
                cmd.Parameters.AddWithValue("@examdate",exam_date.Text);
                cmd.Parameters.AddWithValue("@examstarttime", exam_starttime.Text);
                cmd.Parameters.AddWithValue("@examendtime", exam_endtime.Text);
                cmd.Parameters.AddWithValue("@markofexam", exam_mark.Text);


                cmd.ExecuteNonQuery();
                con.Close();


                Response.Write("<script>alert('data is submitted')</script>");
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString() + ".....");
            }
        }

        protected void semesterDropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string program = programeDropDownList1.SelectedValue;
            string sem = semesterDropDownList2.SelectedValue;

            string query = $"select * from examdetail where programe='{program}' and semester='{sem}' ;" +
                $"select * from subjectdetail where programe='{program}' and semester='{sem}'" ;
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            examnameDropDownList1.DataSource = ds.Tables[0].DefaultView;
            examnameDropDownList1.DataTextField = "examname";
            examnameDropDownList1.DataValueField = "id";
            examnameDropDownList1.DataBind();

            subjectDropDownList3.DataSource = ds.Tables[1].DefaultView;
            subjectDropDownList3.DataTextField = "subject";
            subjectDropDownList3.DataValueField = "id";
            subjectDropDownList3.DataBind();




        }

        protected void reset_Click(object sender, EventArgs e)
        {
            programeDropDownList1.SelectedIndex = 0;
            semesterDropDownList2.SelectedIndex = 0;
            examnameDropDownList1.SelectedIndex = 0;
            subjectDropDownList3.SelectedIndex = 0;
            exam_date.Text = string.Empty;
            exam_starttime.Text = string.Empty;
            exam_endtime.Text = string.Empty;
            exam_mark.Text = string.Empty;
        }
    }
}