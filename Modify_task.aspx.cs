using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class Modify_task : System.Web.UI.Page
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

            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            Label7.Visible = false;
            Label8.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            TextBox5.Visible = false;
            TextBox6.Visible = false;
            Calendar1.Visible = false;
            Button7.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox5.Text = Convert.ToString(Calendar1.SelectedDate);
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string value = Convert.ToString(GridView1.SelectedValue);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Assignment] WHERE ([assignment_id] LIKE '%' + '{value}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            DetailsView1.DataSource = reader;
            DetailsView1.DataBind();
            con.Close();

            Label4.Visible = true;
            Label5.Visible = true;
            Label6.Visible = true;
            Label7.Visible = true;
            Label8.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            Calendar1.Visible = true;
            Button7.Visible = true;


        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string assignment_name = Convert.ToString(TextBox3.Text);
            string task_description = Convert.ToString(TextBox4.Text);
            string deadline = Convert.ToString(TextBox5.Text);
            string max_score = Convert.ToString(TextBox6.Text);
            int value = Convert.ToInt32(GridView1.SelectedValue);

            string subject_name = Convert.ToString(Session["bind"]);

            string updateQuery = "UPDATE [Assignment] SET ";

            List<string> updateFields = new List<string>();

            if (!string.IsNullOrEmpty(assignment_name))
            {
                updateFields.Add($"[assignment_name] = '{assignment_name}'");
            }

            if (!string.IsNullOrEmpty(task_description))
            {
                updateFields.Add($"[task_description] = '{task_description}'");
            }

            if (!string.IsNullOrEmpty(deadline))
            {
                updateFields.Add($"[deadline] = '{deadline}'");
            }

            if (!string.IsNullOrEmpty(max_score))
            {
                updateFields.Add($"[max_score] = '{max_score}'");
            }

            updateQuery += string.Join(", ", updateFields);

            updateQuery += $" WHERE ([assignment_id] = '{value}')";

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand(updateQuery, con);

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                Label8.Text = "Данные успешно изменены";
            }
            catch (Exception ex)
            {
                Label8.Text = ex.Message;
                con.Close();
            }

            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con2.Open();
            SqlCommand cmd2 = new SqlCommand($"SELECT * FROM [Assignment] WHERE ([subject_name] LIKE '%' + '{subject_name}' + '%')", con2);

            SqlDataReader reader2 = cmd2.ExecuteReader();

            GridView1.DataSource = reader2;
            GridView1.DataBind();


            con.Close();
        }
    }
}