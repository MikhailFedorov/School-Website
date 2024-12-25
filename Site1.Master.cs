﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender1, EventArgs e)
        {
            string username = Convert.ToString(Session["username"]);
            string role = Convert.ToString(Session["role"]);
            long id = Convert.ToInt32(Session["id"]);
            LinkButton4.Visible = false;
            if (id != 0)
            {
                if (role == "pupil")
                {
                    LinkButton4.Visible = true;
                }
                Button4.Visible = false;
                Button5.Visible = false;
                Button6.Visible = true;
                Label2.Visible = false;
                Label3.Visible = false;
                TextBox1.Visible = false;
                TextBox2.Visible = false;
                Label1.Text = "Привет, " + role + " " + Session["username"];
            }
            else
            {
                Button4.Visible = true;
                Button5.Visible = true;
                Button6.Visible = false;
                Label2.Visible = true;
                Label3.Visible = true;
                TextBox1.Visible = true;
                TextBox2.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Timetable.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assignments.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True; TrustServerCertificate=True; MultipleActiveResultSets=True");

            string password, login;
            password = Convert.ToString(TextBox2.Text);
            login = Convert.ToString(TextBox1.Text);

            con.Open();
            SqlCommand cmd = new SqlCommand($"SELECT * FROM [Teacher] WHERE ([teacher_login] = '{login}' AND [teacher_password] = '{password}')", con);
            SqlDataReader reader = cmd.ExecuteReader();
            SqlCommand cmd2 = new SqlCommand($"SELECT * FROM [Pupil] WHERE ([pupil_login] = '{login}' AND [pupil_password] = '{password}')", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    Session["username"] = Convert.ToString(reader["teacher_name"]);
                    Session["id"] = Convert.ToInt32(reader["teacher_id"]);
                    int id = Convert.ToInt32(Session["id"]);
                    Session["role"] = "teacher";
                    string role = Convert.ToString(Session["role"]);
                    Button4.Visible = false;
                    Button5.Visible = false;
                    Button6.Visible = true;
                    Label2.Visible = false;
                    Label3.Visible = false;
                    TextBox1.Visible = false;
                    TextBox2.Visible = false;
                    Label1.Text = "Привет, " + role + " " + Session["username"];

                    if (id == 1)
                    {
                        Session["bind"] = "Физика";
                    }
                    else
                    {
                        Session["bind"] = "История";
                    }

                    Response.Redirect("IndexAdmin.aspx");
                }
                else if (reader2.Read())
                {
                    Session["username"] = Convert.ToString(reader2["pupil_name"]);
                    Session["id"] = Convert.ToInt32(reader2["pupil_id"]);
                    Session["role"] = "pupil";
                    string role = Convert.ToString(Session["role"]);
                    Button4.Visible = false;
                    Button5.Visible = false;
                    Button6.Visible = true;
                    Label2.Visible = false;
                    Label3.Visible = false;
                    TextBox1.Visible = false;
                    TextBox2.Visible = false;
                    LinkButton4.Visible = true;
                    Label1.Text = "Привет, " + role + " " + Session["username"];
                }
                else
                {
                    Label1.Text = "Неправильный логин или пароль";
                    Button4.Visible = true;
                    Button5.Visible = true;
                    Button6.Visible = false;
                    Label2.Visible = true;
                    Label3.Visible = true;
                    TextBox1.Visible = true;
                    TextBox2.Visible = true;
                }
                con.Close();
            }
            catch(Exception ex1)
            {
                Label1.Text = ex1.Message;
                con.Close();
                return;
            }
            
        }

        protected void Button6_Click(object sender, EventArgs e) 
        { 
            Session.Clear();
            Response.Redirect("Index.aspx");
        }
    }
}