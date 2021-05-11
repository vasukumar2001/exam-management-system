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
    public partial class index : System.Web.UI.Page
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

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                string qurey = "insert into studentdetail(enrollmentno,fullname,birthdate,gender,mobileno,email,address,programe,semester) values(@enrollmentno,@fullname,@birthdate,@gender,@mobileno,@email,@address,@programe,@semester)";
                SqlCommand cmd = new SqlCommand(qurey, con);
                cmd.Parameters.AddWithValue("@enrollmentno",enrollmentno.Text);
                cmd.Parameters.AddWithValue("@fullname",fullname.Text);
                cmd.Parameters.AddWithValue("@birthdate",birthdate.Text);
                cmd.Parameters.AddWithValue("@gender", gender.SelectedValue);
                cmd.Parameters.AddWithValue("@mobileno",mobileno.Text);
                cmd.Parameters.AddWithValue("@email",email.Text);
                cmd.Parameters.AddWithValue("@address",address.Text);
                cmd.Parameters.AddWithValue("@programe", programeDropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@semester", semesterDropDownList2.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                

                Response.Write("<script>alert('data is submitted')</script>");
                
            }catch(Exception ex)
            {
                Response.Write("Error:" + ex.ToString());
            }
           
        }
        
        protected void reset_Click(object sender, EventArgs e)
        {
            enrollmentno.Text = string.Empty;
            fullname.Text = string.Empty;
            birthdate.Text = string.Empty;
            gender.SelectedValue = "male";
            mobileno.Text = string.Empty;
            email.Text = string.Empty;
            address.Text = string.Empty;
            programeDropDownList1.SelectedIndex= 0;
            semesterDropDownList2.SelectedIndex = 0;
        }

        protected void address_TextChanged(object sender, EventArgs e)
        {

        }
    }
}