using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pupil_id = Convert.ToInt32(Session["id"]);
            int task_id = Convert.ToInt32(Session["task_id"]);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT [report_id], [assignment_id], [assignment_name], [pupil_id], [subject_name], [status] FROM [Report] WHERE ([pupil_id] = '{pupil_id}') ", con);

            SqlDataReader reader = cmd.ExecuteReader();

            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string password, login;
            int id = Convert.ToInt32(Session["id"]);
            password = Convert.ToString(TextBox4.Text);
            login = Convert.ToString(TextBox3.Text);

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand($"UPDATE [Pupil] SET [pupil_password] = '{password}', [pupil_login] = '{login}' WHERE ([pupil_id] = '{id}')", con);
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                Label10.Text = "Данные успешно изменены";
            }
            catch (Exception ex)
            {
                Label10.Text = ex.Message;
                con.Close();
            }
        }
    }
}