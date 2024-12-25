using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class Timetable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Timetable", con);

            SqlDataReader reader = cmd.ExecuteReader();

            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();

            con.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT day_name FROM weekdays", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            DropDownList1.DataSource = reader2;
            DropDownList1.DataBind();
            con.Close();

            con.Open();
            SqlCommand cmd3 = new SqlCommand("SELECT subject_name FROM Assignment", con);
            SqlDataReader reader3 = cmd3.ExecuteReader();
            DropDownList2.DataSource = reader3;
            DropDownList2.DataBind();
            con.Close();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView list = (GridView)sender;
            int value = (int)list.SelectedValue;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Timetable] WHERE ([timetable_id] LIKE '%' + '{value}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            DetailsView1.DataSource = reader;
            DetailsView1.DataBind();
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Timetable] WHERE ([weekday_name] LIKE '%' + '{DropDownList1.SelectedValue}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Timetable] WHERE ([subject_name] LIKE '%' + '{DropDownList2.SelectedValue}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Timetable] WHERE ([weekday_name] LIKE '%' + '{DropDownList1.SelectedValue}' + '%') AND ([subject_name] LIKE '%' + '{DropDownList2.SelectedValue}' + '%')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Timetable", con);

            SqlDataReader reader = cmd.ExecuteReader();

            GridView1.DataSource = reader;
            GridView1.DataBind();
            con.Close();
        }

    }
}