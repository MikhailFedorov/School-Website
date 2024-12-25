using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace School
{
    public partial class Upload_task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            string bind = Convert.ToString(Session["bind"]);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Assignment WHERE ([subject_name] LIKE '%' + '" + bind + "' + '%')", con);

            SqlDataReader reader = cmd.ExecuteReader();

            GridView1.DataSource = reader;
            GridView1.DataBind();


            con.Close();

            Label10.Visible = false;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();

            string assignment_name, task_description, deadline, max_score, subject_name;
            assignment_name = Convert.ToString(TextBox3.Text);
            task_description = Convert.ToString(TextBox4.Text);
            deadline = Convert.ToString(TextBox6.Text);
            max_score = Convert.ToString(TextBox5.Text);
            subject_name = Convert.ToString(Session["bind"]);

            SqlCommand cmd = new SqlCommand($"INSERT INTO Assignment(assignment_name, task_description, deadline, max_score, subject_name) VALUES ('{assignment_name}', '{task_description}', '{deadline}', '{max_score}', '{subject_name}')", con);
            cmd.ExecuteNonQuery();

            Label10.Visible = true;
            Label10.Text = "Задание успешно добавлено";

            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con2.Open();
            SqlCommand cmd2 = new SqlCommand($"SELECT * FROM [Assignment] WHERE ([subject_name] LIKE '%' + '{subject_name}' + '%')", con2);

            SqlDataReader reader2 = cmd2.ExecuteReader();

            GridView1.DataSource = reader2;
            GridView1.DataBind();


            con.Close();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox6.Text = Convert.ToString(Calendar1.SelectedDate);
        }

    }
}