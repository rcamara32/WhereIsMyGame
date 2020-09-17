using System.Collections.Generic;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public int ErroCode { get; set; }
        public string Error { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public List<string> ErrorMessages { get; set; }
    }
}
