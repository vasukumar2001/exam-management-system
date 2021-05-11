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
    public partial class manage_exam : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView();
        }

        private void GridView()
        {
            string query = "select ed.id,ed.examname,pd.programe,st.semester from examdetail as ed  join programedetail pd on ed.programe=pd.ID  inner join semesterdetail as st on ed.semester=st.id";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                string data = GridView1.Rows[id].Cells[1].Text;
                Response.Redirect("update_examname.aspx?id=" + data);

                e.Handled = true;
            }
            else if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                string did = GridView1.Rows[id].Cells[1].Text;


                string qurey = "Delete from examdetail where id='" + did + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.ExecuteNonQuery();
                con.Close();
            GridView();

                e.Handled = true;


            }
            else
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query = " select ed.id, ed.examname ,pd.programe, se.semester from examdetail as ed join programedetail as pd on ed.programe=pd.ID  inner join semesterdetail as se on  ed.semester=se.id where ed.id like'%" + TextBox1.Text + "%' or ed.examname like'%" + TextBox1.Text + "%' or pd.programe like'%" + TextBox1.Text + "%' or se.semester like'%" + TextBox1.Text + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}