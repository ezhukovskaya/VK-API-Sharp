namespace VK.Application.Models
{
    public class User
    {
        private string _login;
        private string _password;
        private string _token;

        public string Login
        {
            get => _login;
            set => _login = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string Token
        {
            get => _token;
            set => _token = value;
        }

        public User(string login, string password, string token)
        {
            this._login = login;
            this._password = password;
            this._token = token;
        }
    }
}