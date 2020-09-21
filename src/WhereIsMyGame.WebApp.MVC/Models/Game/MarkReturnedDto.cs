using System;
using WhereIsMyGame.WebApp.MVC.Extensions;

namespace WhereIsMyGame.WebApp.MVC.Models
{
    public class MarkReturnedDto
    {
        public Guid GameId { get; set; }

        [DateGreaterThan("LastDateLoan", "Returned Date must be greater than Created Date")]
        public DateTime ReturnedDate { get; set; }

        public DateTime? LastDateLoan { get; set; }

    }
}
