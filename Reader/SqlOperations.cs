using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Reader
{
    public class SqlOperations
    {
        private SqlConnection _sqlConn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\reader.mdf;Integrated Security=True");

        public bool IsConnectionOpen()
        {
            if (_sqlConn.State == ConnectionState.Open) return true;
            return false;
        }

        public void OpenConnection()
        {
            _sqlConn.Open();
        }

        public void CloseConnection()
        {
            _sqlConn.Close();
        }


        public void DeletePostById(int pid)
        {
            string updateSql = "DELETE FROM [dbo].[Post] WHERE [Id] = @id";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            cmd.Parameters.AddWithValue("@id", pid);
            cmd.ExecuteNonQuery(); 
        }

        public List<Article> GetLatestArticles()
        {
            string updateSql = "SELECT TOP 20 * from [dbo].[Post]";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            var articleList = new List<Article>();
            while (reader.Read())
            {
                Article temp = ReadSingleRow((IDataRecord)reader);
                articleList.Add(temp);
            }

            return articleList;
        }

        public List<Article> GetSavedArticlesByUser(int uid)
        {


            string updateSql = "SELECT * FROM [dbo].[Post] WHERE [Id] IN (SELECT [ArticleId] FROM [dbo].[SavePosts] WHERE [UserId] = @uid)";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            cmd.Parameters.AddWithValue("@uid", uid);
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            var articleList = new List<Article>();
            while (reader.Read())
            {
                Article temp = ReadSingleRow((IDataRecord)reader);
                articleList.Add(temp);
            }

            return articleList;
        }

        public int SavePost(string title, string summary, string body, string tags, int authId)
        {
            string updateSql = "INSERT INTO [dbo].[Post] ([authorId], [title], [summary], [body], [tags], [publishTime]) VALUES (@authId, @title, @summ, @body, @tg, @pubtime)";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            cmd.Parameters.AddWithValue("@authId", authId);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@summ", summary);
            cmd.Parameters.AddWithValue("@tg", tags);
            cmd.Parameters.AddWithValue("@body", body);
            cmd.Parameters.AddWithValue("@pubtime", DateTime.UtcNow);

            int updated = cmd.ExecuteNonQuery();

            return updated;
        }

        public int SaveArticleToUser(int pid, int uid)
        {
            string updateSql = "INSERT INTO [dbo].[SavePosts] ([ArticleId], [UserId]) VALUES (@pid, @uid)";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            cmd.Parameters.AddWithValue("@pid", pid);
            cmd.Parameters.AddWithValue("@uid", uid);

            int updated = cmd.ExecuteNonQuery();

            return updated;
            
        }

        public Article GetArticleById(int Id)
        {
            string updateSql = "SELECT * from [dbo].[Post] WHERE [Id] = @id";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            cmd.Parameters.AddWithValue("@id", Id);
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            int authId = reader.GetInt32(reader.GetOrdinal("authorId"));
            int likes = reader.GetInt32(reader.GetOrdinal("likes"));
            string title = reader.GetString(reader.GetOrdinal("title"));
            string summary = reader.GetString(reader.GetOrdinal("summary"));
            string body = reader.GetString(reader.GetOrdinal("body"));
            string tags = reader.GetString(reader.GetOrdinal("tags"));
            DateTime dt = reader.GetDateTime(reader.GetOrdinal("publishTime"));
            return new Article(id, authId, likes, title, summary, body, tags, dt);
        }

        public List<Tuple<int, string>> GetUsersNameId()
        {
            string updateSql = "SELECT [id], [name] from [dbo].[User]";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            List<Tuple<int, string>> uList = new List<Tuple<int, string>>();

            while (reader.Read())
            {
                Tuple<int, string> temp = ReadSingUserRow((IDataRecord)reader);
                uList.Add(temp);
            }

            return uList;
        }

        private Tuple<int, string> ReadSingUserRow(IDataRecord dr)
        {
            return new Tuple<int, string>((int)dr[0], (string)dr[1]);
        }

        public Article GetArticleByTitleAndAuthor(string TitleName, int AuthId)
        {
            string updateSql = "SELECT * from [dbo].[Post] WHERE [title] = @title AND [authorId] = @authId";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            cmd.Parameters.AddWithValue("@title", TitleName);
            cmd.Parameters.AddWithValue("@authId", AuthId);
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            int authId = reader.GetInt32(reader.GetOrdinal("authorId"));
            int likes = reader.GetInt32(reader.GetOrdinal("likes"));
            string title = reader.GetString(reader.GetOrdinal("title"));
            string summary = reader.GetString(reader.GetOrdinal("summary"));
            string body = reader.GetString(reader.GetOrdinal("body"));
            string tags = reader.GetString(reader.GetOrdinal("tags"));
            DateTime dt = reader.GetDateTime(reader.GetOrdinal("publishTime"));
            return new Article(id, authId, likes, title, summary, body, tags, dt);
        }

        public void SetLikesByPostId(int likeCount, int pId)
        {
            string updSql = @"update [dbo].[Post] 
                      set [likes] = [likes] + @lk 
                      where [Id] = @pid";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@lk", likeCount);
            cmd.Parameters.AddWithValue("@pid", pId);
            cmd.ExecuteNonQuery();
        }

        public List<Article> GetArticlesTopArticlesByAuthor(int authId)
        {
            string updateSql = "SELECT TOP 3 * from [dbo].[Post] WHERE [authorId] = @authId ORDER BY NEWID()";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            cmd.Parameters.AddWithValue("@authId", authId);
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            var articleList = new List<Article>();
            while (reader.Read())
            {
                Article temp = ReadSingleRow((IDataRecord)reader);
                articleList.Add(temp);
            }

            return articleList;
        }

       

        public int EditPost(int pId, string title, string summary, string body, string tags)
        {
            string updSql = @"UPDATE [dbo].[Post] 
                      SET [title] = @title, 
                          [summary] = @summary,
                          [body] = @body,
                          [tags] = @tags                           
                      WHERE [Id] = @id";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@id", pId);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@summary", summary);
            cmd.Parameters.AddWithValue("@body", body);
            cmd.Parameters.AddWithValue("@tags", tags);
            int updated = cmd.ExecuteNonQuery();
            return updated;
        }

        public List<Article> GetArticlesByAuthor(int authId)
        {
            string updateSql = "SELECT * from [dbo].[Post] WHERE [authorId] = @authId ORDER BY [publishTime] DESC";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updateSql;
            cmd.Parameters.AddWithValue("@authId", authId);
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            var articleList = new List<Article>();
            while (reader.Read())
            {
                Article temp = ReadSingleRow((IDataRecord)reader);
                articleList.Add(temp);
            }

            return articleList;
        }

        private Article ReadSingleRow(IDataRecord dr)
        {
            return new Article((int)dr[0], (int)dr[1], (int)dr[7], (string)dr[2], (string)dr[3], (string)dr[4], (string)dr[5],(DateTime)dr[6]);
        }
        public int GetUserId(string uname)
        {
            string updSql = @"select [Id] from [User] where username = @uname";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@uname", uname);
            int res = (int)cmd.ExecuteScalar();
            return res;
        }

        public string GetAuthorNameById(int id)
        {
            string updSql = @"select [name] from [User] where [Id] = @id";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@id", id);
            string res = (string)cmd.ExecuteScalar();
            return res;
        }

        public string GetPicNameById(int id)
        {
            string updSql = @"select [picture] from [User] where [Id] = @id";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@id", id);
            string res = (string)cmd.ExecuteScalar();
            return res;
        }

        public User GetUserData(string uname)
        {
            string updSql = @"select * from [User] where username = @uname";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@uname", uname);
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            int id = reader.GetInt32(reader.GetOrdinal("Id"));
            string name = reader.GetString(reader.GetOrdinal("name"));
            string email = reader.GetString(reader.GetOrdinal("email"));
            string pass = reader.GetString(reader.GetOrdinal("password"));
            string prof = string.Empty;
            string bio = string.Empty;
            string path = string.Empty;
            if (!reader.IsDBNull(reader.GetOrdinal("bio"))) bio = reader.GetString(reader.GetOrdinal("bio"));
            if (!reader.IsDBNull(reader.GetOrdinal("profession"))) prof = reader.GetString(reader.GetOrdinal("profession"));
            if (!reader.IsDBNull(reader.GetOrdinal("picture"))) path = reader.GetString(reader.GetOrdinal("picture"));
            this.CloseConnection();

            return new User(id, name, uname, email, pass, prof, bio, path);
        }

        public int UpdateUserName(string uname, string name)
        {
            string updSql = @"update [User] 
                      set name = @name 
                      where username = @uName";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@uName", uname);
            cmd.Parameters.AddWithValue("@name", name);
            int updated = cmd.ExecuteNonQuery();
            return updated;
        }

        public int UpdateUserEmail(string uname, string email)
        {
            string updSql = @"update [User] 
                      set email = @email 
                      where username = @uName";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@uName", uname);
            cmd.Parameters.AddWithValue("@email", email);
            int updated = cmd.ExecuteNonQuery();

            return updated;
        }

        public int UpdateUserPassword(string uname, string newpass)
        {
            string updSql = @"update [User] 
                      set password = @pass
                      where username = @uName";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@uName", uname);
            cmd.Parameters.AddWithValue("@pass", newpass);
            int updated = cmd.ExecuteNonQuery();

            return updated;
        }

        public string GetUserPassword(string uname)
        {
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select password from [User] where username=@uname";
            cmd.Parameters.AddWithValue("@uname", uname);
            var res = cmd.ExecuteScalar();
            this.CloseConnection();
            return res.ToString();
        }

        public int  UpdateUserProfession(string uname, string prof)
        {
            SqlTransaction sqlTransaction = _sqlConn.BeginTransaction();
            string updSql = @"update [User] 
                      set [profession] = @prof 
                      where [username] = @uName";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@uName", uname);
            cmd.Parameters.AddWithValue("@prof", prof);

            cmd.Transaction = sqlTransaction;
            int updated = cmd.ExecuteNonQuery();
            sqlTransaction.Commit();
            return updated;
        }

        public int  UpdateUserBio(string uname, string bio)
        {
            string updSql = @"update [dbo].[User] set [bio]='"+bio+"' where [username]='"+uname+"'";

                SqlCommand cmd = _sqlConn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = updSql;
                //cmd.Parameters.AddWithValue("@uName", uname);
                //cmd.Parameters.AddWithValue("@bio", bio);
                int updated = cmd.ExecuteNonQuery();
                return updated;
        }

        public void UpdateUserPicture(string uname, string path)
        {
            string updSql = @"update [User] 
                      set picture = @pic
                      where username = @uName";
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = updSql;
            cmd.Parameters.AddWithValue("@uName", uname);
            cmd.Parameters.AddWithValue("@pic", path);
            int updated = cmd.ExecuteNonQuery();

        }

        public void CreateUser(string name, string username, string email, string pass)
        {
            try
            {
                SqlCommand cmd = _sqlConn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into [User] (name, username, email, password) values('" + name + "', '" + username + "', '" + email + "', '" + pass + "')";
                cmd.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                throw err;
            }
        }

        public Tuple<string, string, string, string> GetUser(string uName)
        {
            SqlCommand cmd = _sqlConn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [User] where username=@uname";
            cmd.Parameters.AddWithValue("@uname", uName);
            var reader = cmd.ExecuteReader();

            if (!reader.Read())
            {
                throw new InvalidOperationException("No records were returned");
            }

            string name = reader.GetString(reader.GetOrdinal("name"));
            string email = reader.GetString(reader.GetOrdinal("email"));
            string prof = string.Empty;
            string bio = string.Empty;

            if(!reader.IsDBNull(reader.GetOrdinal("bio"))) bio = reader.GetString(reader.GetOrdinal("bio"));
            if (!reader.IsDBNull(reader.GetOrdinal("profession"))) bio = reader.GetString(reader.GetOrdinal("profession"));
            return new Tuple<string,string,string, string>(name, email, prof, bio);

        }

        public bool DoesUserExist(string uName, string emailStr)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = _sqlConn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from [User] where username='" + uName + "' or email='" + emailStr + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dt);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }

            if (dt.Rows.Count < 1) return false;
            return true;
        }
    }
}