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
    public partial class WebForm3 : System.Web.UI.Page
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

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                string qurey = "insert into subjectdetail(subject,subjectcode,programe,semester) values(@subject,@subjectcode,@programe,@semester)";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@subject", subject.Text);
                cmd.Parameters.AddWithValue("@subjectcode", subjectcode.Text);
                cmd.Parameters.AddWithValue("@programe", programeDropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@semester", semesterDropDownList2.SelectedValue);


                cmd.ExecuteNonQuery();
                con.Close();


                Response.Write("<script>alert('data is submitted')</script>");
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString()+".....");
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            subject.Text = string.Empty;
            subjectcode.Text = string.Empty;
            programeDropDownList1.SelectedIndex = 0;
            semesterDropDownList2.SelectedIndex = 0;
        }
    }
}