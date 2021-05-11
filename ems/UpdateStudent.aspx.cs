using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ems
{
    public partial class UpdateStudent : System.Web.UI.Page
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

                    string query = "select * from studentdetail where id="+id;
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query,con);
                    SqlDataReader rd = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            enrollmentno.Text = rd[1].ToString();
                            fullname.Text = rd[2].ToString();
                            birthdate.Text = (Convert.ToDateTime(rd[3]).ToString("yyyy-MM-dd"));
                            gender.SelectedValue = rd[4].ToString();
                            mobileno.Text = rd[5].ToString();
                            email.Text = rd[6].ToString();
                            address.Text = rd[7].ToString();
                            programeDropDownList1.SelectedValue = rd[8].ToString();
                            semesterDropDownList2.SelectedValue = rd[9].ToString();
                        }
                    }
                }

            }

        }

        protected void gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
            
        {
            
                int id = 0;
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    id = Convert.ToInt16(Request.QueryString["id"]);
                    con.Open();
                    string qurey = "UPDATE  studentdetail SET enrollmentno='" + enrollmentno.Text + "', fullname='" + fullname.Text + "',birthdate='" + birthdate.Text + "',gender='" + gender.SelectedValue + "',mobileno='" + mobileno.Text + "',email='" + email.Text + "',address='" + address.Text + "',programe='" + programeDropDownList1.Text + "',semester='" + programeDropDownList1.SelectedValue + "' WHERE id='" + id + "'";
                    SqlCommand cmd = new SqlCommand(qurey, con);

                    cmd.ExecuteNonQuery();
                       
                        Response.Redirect("Student_detail.aspx");
                    
                }
           
        }
      
    }
}