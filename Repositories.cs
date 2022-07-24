using System.Data.Common;
using System.Data.SQLite;

using authenticator.Models;

namespace authenticator.Repositories
{
    public class UserRepository 
    {
        private SQLiteConnection conn;

        public UserRepository(SQLiteConnection connection)
        {
            conn = connection;
        }

        public User? GetByEmail(string email)
        {
            string queryString = "SELECT * FROM users WHERE email like @email";
            using (SQLiteCommand cmd = new SQLiteCommand(queryString, conn))
            {
                cmd.Parameters.AddWithValue("@email", email);

                SQLiteDataReader rdr = cmd.ExecuteReader();

                if(rdr.Read())
                {
                    User user = new User(
                        userId: (long)rdr["id"],
                        name: rdr["name"].ToString()!,
                        email: rdr["email"].ToString()!,
                        password: rdr["password"].ToString()!
                    );
                    return user;
                }
            }
            return null;
        }
    }
}