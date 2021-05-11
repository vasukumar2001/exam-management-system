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
    public partial class upadate_programe : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

            
            int id = 0;
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    id = Convert.ToInt16(Request.QueryString["id"]);

                    string query = "select * from programedetail where id=" + id;
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            programe.Text = rd[1].ToString();
                            programecode.Text = rd[2].ToString();
                            
                        }
                    }
                }

            }
            
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                id = Convert.ToInt16(Request.QueryString["id"]);
                con.Open();
                string qurey = "UPDATE  programedetail SET programe='" + programe.Text + "', programecode='" + programecode.Text + "'WHERE id='" + id + "'";
                SqlCommand cmd = new SqlCommand(qurey, con);

                cmd.ExecuteNonQuery();

                Response.Redirect("manage_programe.aspx");

            }
        }
    }
}