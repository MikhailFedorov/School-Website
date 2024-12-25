using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace School
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = "Введите данные";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True");
            con.Open();
            if (Page.IsValid)
            {
                string sname, ssurname, smidname, sphone, slogin, spassword, srole;
                sname = Convert.ToString(TextBox1.Text);
                ssurname = Convert.ToString(TextBox2.Text);
                smidname = Convert.ToString(TextBox3.Text);
                sphone = Convert.ToString(TextBox4.Text);
                slogin = Convert.ToString(TextBox5.Text);
                spassword = Convert.ToString(TextBox6.Text);
                srole = Convert.ToString(DropDownList1.SelectedValue);

                

                try
                {
                    if (srole == "teacher")
                    {
                        SqlCommand cmd = new SqlCommand($"INSERT INTO Teacher(teacher_name, teacher_surname, teacher_midname, teacher_phone, teacher_login, teacher_password) VALUES ('{sname}', '{ssurname}', '{smidname}', '{sphone}', '{slogin}', '{spassword}')", con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (srole == "pupil")
                    {
                        SqlCommand cmd = new SqlCommand($"INSERT INTO Pupil(pupil_name, pupil_surname, pupil_midname, pupil_phone, pupil_login, pupil_password) VALUES ('{sname}', '{ssurname}', '{smidname}', '{sphone}', '{slogin}', '{spassword}')", con);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();

                    Label3.Text = "Пользователь добавлен";
                }
                catch (Exception ex1) 
                {
                    Label3.Text = ex1.Message;
                    con.Close();
                    return;
                }

            }
        }
    }
}