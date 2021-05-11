using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ems
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
       
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            
            
        }

        

        protected void login_Click(object sender, EventArgs e)
        {
            string constr = WebConfigurationManager.ConnectionStrings["db"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from logindata where username='"+username.Text+"' and password='"+password.Text+"'",con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cmd.ExecuteNonQuery();
                if(dt.Rows[0][0].ToString()=="1")
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('please enter valid entery')</script>");

                }
                
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}