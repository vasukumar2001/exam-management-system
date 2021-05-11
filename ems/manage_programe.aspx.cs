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
    public partial class manage_programe : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Grid_Refresh();

            
        }
        private void Grid_Refresh()
        {
            string query = "select * from programedetail ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                string data = GridView1.Rows[id].Cells[1].Text;
                Response.Redirect("updateprograme.aspx?id=" + data);

                e.Handled = true;
            }
            else if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                string did = GridView1.Rows[id].Cells[1].Text;


                string qurey = "Delete from programedetail where id='" + did + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.ExecuteNonQuery();
                
                con.Close();
                Grid_Refresh();
                e.Handled = true;

            }
            else
            {

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from programedetail where id like'%"+ TextBox1.Text + "%' or  programe like'%" + TextBox1.Text + "%' or programecode like'%" + TextBox1.Text + "%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}