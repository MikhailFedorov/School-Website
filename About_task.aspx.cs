using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class About_task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pupil_id = Convert.ToInt32(Session["id"]);
            int task_id = Convert.ToInt32(Session["task_id"]);  
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT [report_id], [assignment_id], [assignment_name], [pupil_id], [subject_name], [status], [report_text], [attached_file] FROM [Report] WHERE ([pupil_id] = '{pupil_id}' AND [assignment_id] = '{task_id}') ", con);

            SqlDataReader reader = cmd.ExecuteReader();

            DetailsView1.DataSource = reader;
            DetailsView1.DataBind();
            con.Close();
        }
    }
}