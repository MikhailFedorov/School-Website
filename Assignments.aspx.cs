using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class Assignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Assignment", con);
            
            SqlDataReader reader = cmd.ExecuteReader();
            
            GridView1.DataSource = reader;
            GridView1.DataBind();
            
            
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT subject_name FROM Assignment", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            DropDownList1.DataSource = reader2;
            DropDownList1.DataBind();
            con.Close();

            Button7.Visible = false;
            Label4.Visible = false;
            TextBox3.Visible = false;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Assignment] WHERE ([subject_name] LIKE '%' + '{value}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            string crit;
            crit = "SELECT * FROM Assignments";
            SqlDataSource1.SelectCommand = crit;
            SqlDataSource1.DataBind();
        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            string crit;
            crit = "SELECT * FROM Assignments";
            SqlDataSource2.SelectCommand = crit;
            SqlDataSource2.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView list = (GridView)sender;
            int value = (int)list.SelectedValue;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Assignment] WHERE ([assignment_id] LIKE '%' + '{value}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            DetailsView1.DataSource = reader;
            DetailsView1.DataBind();
            con.Close();

            GridViewRow row = GridView1.SelectedRow;
            Button7.Visible = true;
            TextBox3.Visible = true;
            Session["task_id"] = GridView1.SelectedValue;
            Session["task_name"] = row.Cells[3].Text;
            Session["subject_name"] = row.Cells[1].Text;
            Button7.Text = "Загрузить отчет по заданию " + row.Cells[3].Text;

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            long client_id = Convert.ToInt32(Session["id"]);
            long task_id = Convert.ToInt32(Session["task_id"]);
            string role = Convert.ToString(Session["role"]);
            string subject_name = Convert.ToString(Session["subject_name"]);
            string report_text = Convert.ToString(TextBox3.Text);
            string fileName = FileUpload1.FileName;

            Label4.Visible = true;

            if (client_id == 0)
            {
                Label4.Text = "Для загрузки отчета необходимо авторизоваться";
            }
            else if (role == "teacher")
            {
                Label4.Text = "Учитель не может загружать ответ на задание";
            }
            else
            {

                Label4.Text = "Ответ предоставлен";
                string task_name = Convert.ToString(Session["task_name"]);
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand($"INSERT INTO [Report] ([pupil_id], [assignment_id], [assignment_name], [subject_name], [status], [report_text], [attached_file]) VALUES ({client_id}, {task_id}, '{task_name}', '{subject_name}', 'Ожидает проверки', '{report_text}', '{fileName}')", con);
                SqlDataReader reader = cmd.ExecuteReader();
                Response.Redirect("About_task.aspx");
            }
        }

    }
}