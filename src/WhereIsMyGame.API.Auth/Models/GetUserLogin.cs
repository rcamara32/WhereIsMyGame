namespace WhereIsMyGame.Auth.API.Models
{
    public class GetUserLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }

}
