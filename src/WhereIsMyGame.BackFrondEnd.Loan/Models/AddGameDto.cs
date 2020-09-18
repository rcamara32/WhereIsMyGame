using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyGame.BackFrondEnd.Loan.Models
{
    public class AddGameDto
    {
        public Guid PlataformId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }        
        public string Image { get; set; }
    }
}
