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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {

            try
            {

                con.Open();
                string qurey = "insert into programedetail(programe,programecode) values(@programe,@programecode)";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@programe", programe.Text);
                cmd.Parameters.AddWithValue("@programecode", programecode.Text);
               
                cmd.ExecuteNonQuery();
                con.Close();
                

                Response.Write("<script>alert('data is submitted')</script>");
              
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
        }

       
        protected void reset_Click(object sender, EventArgs e)
        {
            programe.Text = string.Empty;
            programecode.Text = string.Empty;

        }
    }
}