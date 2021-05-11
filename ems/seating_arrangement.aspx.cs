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
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        private int _total = 0;

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
                programeDropDownList1.Items.Insert(0, new ListItem("Select Program"));

                semesterDropDownList2.DataSource = ds.Tables[1].DefaultView;
                semesterDropDownList2.DataTextField = "semester";
                semesterDropDownList2.DataValueField = "id";
                semesterDropDownList2.DataBind();
                semesterDropDownList2.Items.Insert(0, new ListItem("Select Semester"));
            }
        }

     
        
        protected void semesterDropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string program = programeDropDownList1.SelectedValue;
            string sem = semesterDropDownList2.SelectedValue;

            string query = $"select * from examdetail where programe='{program}' and semester='{sem}' select count(id) from studentdetail where programe='{program}' and semester='{sem}'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            examnameDropDownList2.DataSource = ds.Tables[0].DefaultView;
            examnameDropDownList2.DataTextField = "examname";
            examnameDropDownList2.DataValueField = "id";
            examnameDropDownList2.DataBind();

            numberofstudent.Text = ds.Tables[1].Rows[0][0].ToString();

            _total = (int)ds.Tables[1].Rows[0][0];


        }

        protected void save_Click(object sender, EventArgs e)
        {
            int class_limit = Convert.ToInt32(class_seatlimit.Text);
            int total_student = Convert.ToInt32(numberofstudent.Text);


            if (class_limit > 0)
            {
                if (class_limit < total_student)
                {
                   int temp= (total_student / class_limit)+( total_student%class_limit == 0 ? 0: 1 );
                    required_class.Text = temp.ToString();


                    SqlDataAdapter adapter = new SqlDataAdapter($"select * from studentdetail " +
                        $" where programe='{programeDropDownList1.SelectedValue}' and " +
                        $"semester='{semesterDropDownList2.SelectedValue}' ", con);

                   DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    string s = "";
                    int c = 0;
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (i % class_limit == 0)
                        {
                            c++;
                            
                            s += $"<b>class {c} </b><br>";
                            s += "Sr.| Enrolment | Name<br>";
                            

                        }
                        s +=$"{i+1} | "+ dt.Rows[i][1] + " | " + dt.Rows[i][2]+"|<br>";
                    }
                    Literal1.Text = s;

                }
            }
        }

        protected void class_seatlimit_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

