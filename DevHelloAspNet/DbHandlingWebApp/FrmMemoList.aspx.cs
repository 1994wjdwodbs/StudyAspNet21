using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DbHandlingWebApp
{
    public partial class FrmMemoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using (var conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("ListMemo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds, "Memos");

                GrvMemoList.DataSource = ds;
                GrvMemoList.DataBind();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            var connString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            using (var conn = new SqlConnection(connString))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SearchMemo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SearchField", CboSearch.SelectedValue); // Name, Title이 선택될 수 있다.
                cmd.Parameters.AddWithValue("@SearchQuery", TxtSearch.Text.Replace("--", "")); // SQL 주석 공격 방지

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Memos");

                GrvMemoList.DataSource = ds.Tables[0].DefaultView;
                GrvMemoList.DataBind();
            }
        }
    }
}