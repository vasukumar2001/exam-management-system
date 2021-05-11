using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.UI.HtmlControls;

namespace ems
{
    public partial class Student_detail : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView();
        }

        private void GridView()
        {
            string query = "select sd.id,sd.enrollmentno,sd.fullname,sd.birthdate,sd.gender,sd.mobileno,sd.email,sd.address,pd.programe, se.semester from studentdetail as sd join programedetail as pd on sd.programe=pd.ID  inner join semesterdetail as se on  sd.semester=se.id ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
                Response.Redirect("Updatestudent.aspx?id=" + data);

                e.Handled = true;
            }
            else if (e.CommandName == "Delete")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                string did = GridView1.Rows[id].Cells[1].Text;


                string qurey = "Delete from studentdetail where id='" + did + "'";
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

       

        
        

       
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            string query = "select sd.id,sd.enrollmentno,sd.fullname,sd.birthdate,sd.gender,sd.mobileno,sd.email,sd.address,pd.programe, se.semester from studentdetail as sd join programedetail as pd on sd.programe=pd.ID  inner join semesterdetail as se on  sd.semester=se.id  where sd.id like'%" + TextBox1.Text + "%' or sd.fullname like'%" + TextBox1.Text + "%' or sd.address like'%" + TextBox1.Text + "%'  or sd.email like'%" + TextBox1.Text + "%'  or sd.mobileno like'%" + TextBox1.Text + "%'  or sd.gender like'%" + TextBox1.Text + "%'  or sd.birthdate like'%" + TextBox1.Text + "%' or pd.programe like'%" + TextBox1.Text + "%' or se.semester like'%" + TextBox1.Text + "%' ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}