using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class Check_reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            string bind = Convert.ToString(Session["bind"]);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Report WHERE ([subject_name] LIKE '%' + '" + bind + "' + '%')", con);

            SqlDataReader reader = cmd.ExecuteReader();

            GridView1.DataSource = reader;
            GridView1.DataBind();


            con.Close();

            Label4.Visible = false;
            Label5.Visible = false;
            Label6.Visible = false;
            DropDownList2.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            Button7.Visible = false;

        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string status;
            int id = Convert.ToInt32(Session["id"]);
            status = Convert.ToString(DropDownList2.SelectedValue);
            string score = Convert.ToString(TextBox3.Text);
            string comment = Convert.ToString(TextBox4.Text);
            int value = Convert.ToInt32(GridView1.SelectedValue);

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            SqlCommand cmd = new SqlCommand($"UPDATE [Report] SET [status] = '{status}', [score] = '{score}', [comment] = '{comment}' WHERE ([report_id] = '{value}')", con);

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                Label7.Text = "Данные успешно изменены";
            }
            catch (Exception ex)
            {
                Label7.Text = ex.Message;
                con.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string value = (string)list.SelectedValue;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Report] WHERE ([subject_name] LIKE '%' + '{value}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView list = (GridView)sender;
            int value = (int)list.SelectedValue;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Report] WHERE ([report_id] LIKE '%' + '{value}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            DetailsView1.DataSource = reader;
            DetailsView1.DataBind();
            con.Close();

            
            Label4.Visible = true;
            
            DropDownList2.Visible = true;
            
            Button7.Visible = true;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accept = Convert.ToString(DropDownList2.SelectedValue);

            Label6.Visible = true;
            TextBox4.Visible = true;
            if (accept == "Принято")
            {
                Label5.Visible = true;
                TextBox3.Visible = true;
            }
            else
            {
                Label5.Visible = false;
                TextBox3.Visible = false;
            }
        }
    }
}