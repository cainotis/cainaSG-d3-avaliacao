namespace authenticator.Models
{
    public class User
    {
        public long userId;
        public string name {get; set;}
        public string email { get; set; }
        public string password { get; set; }

        public User(long userId, string name, string email, string password)
        {
            this.userId = userId;
            this.name = name;
            this.email = email;
            this.password = password;
        }

    }
}