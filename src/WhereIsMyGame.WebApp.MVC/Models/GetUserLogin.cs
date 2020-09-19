using WhereIsMyGame.Core.Communication;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class GetUserLogin
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
        public ResponseResult ResponseResult { get; set; }
    }
}
