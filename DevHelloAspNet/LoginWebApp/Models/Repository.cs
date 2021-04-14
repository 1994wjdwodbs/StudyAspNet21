using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LoginWebApp.Models
{
    public class Repository
    {
        private SqlConnection conn;

        public Repository()
        {
            // ConfigurationManager : 클라이언트 응용 프로그램의 구성 파일에 액세스할 수 있도록 합니다. 이 클래스는 상속될 수 없습니다.
            this.conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
        }

        internal bool IsCorrectUser(string userId, string password)
        {
            bool result = false;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID AND Password = @Password", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            SqlDataReader dr;
            if ((dr = cmd.ExecuteReader()).Read())
            {
                result = true;
            }
            dr.Close();
            conn.Close();

            return result;
        }

        public int AddUser(string userId, string password)
        {
            // using 구문 없이 시작
            SqlCommand cmd = new SqlCommand("WriteUsers", conn);
            
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            var result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;
        }

        public User GetUserByUserId(string userId)
        {
            User user = new User();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserID = @UserID", conn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@UserID", userId);

            conn.Open();
            // IDataReader 써도 상관 없음
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                user.UID = Convert.ToInt32(reader["UID"]);
                user.UserID = reader["UserID"].ToString();
                user.Password = reader["Password"].ToString();
            }
            conn.Close();

            return user;
        }
    }
}