﻿using System;

namespace WhereIsMyGame.Collection.API.Application.Dto
{
    public class EditGameDto
    {
        public Guid Id { get; set; }
        public Guid PlataformId { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
       
    }
}
