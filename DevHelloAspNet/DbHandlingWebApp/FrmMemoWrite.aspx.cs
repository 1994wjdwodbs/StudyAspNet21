﻿using DbHandlingWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DbHandlingWebApp
{
    public partial class FrmMemoWrite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnWrite_Click(object sender, EventArgs e)
        {
            Memos memos = new Memos();
            memos.Name = TxtName.Text;
            memos.Email = TxtEmail.Text;
            memos.Title = TxtTitle.Text;
            memos.PostDate = DateTime.Now;
            memos.PostIP = Request.UserHostAddress;

            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using (var conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();
                try
                {
                    // 저장 프로시저
                    SqlCommand cmd = new SqlCommand("WriteMemo", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(@"Name", memos.Name);
                    cmd.Parameters.AddWithValue(@"Email", memos.Email);
                    cmd.Parameters.AddWithValue(@"Title", memos.Title);
                    cmd.Parameters.AddWithValue(@"PostDate", memos.PostDate);
                    cmd.Parameters.AddWithValue(@"PostIP", memos.PostIP);

                    cmd.ExecuteNonQuery();

                    LblResult.Text = "저장 완료";
                    
                    // 수동 대입
                    /*
                    var query = @"Insert Memos (Name, Email, Title, PostDate, PostIP) VALUES (@Name, @Email, @Title, @PostDate, @PostIP)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue(@"Name", memos.Name);
                    cmd.Parameters.AddWithValue(@"Email", memos.Email);
                    cmd.Parameters.AddWithValue(@"Title", memos.Title);
                    cmd.Parameters.AddWithValue(@"PostDate", memos.PostDate);
                    cmd.Parameters.AddWithValue(@"PostIP", memos.PostIP);

                    cmd.ExecuteNonQuery();

                    LblResult.Text = "저장 완료"; 
                    */
                }
                catch (Exception ex)
                {
                    LblResult.Text = $"예외발생 : {ex}"; 
                }
            }

        }

        protected void BtnList_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMemoList.aspx");
        }
    }
}