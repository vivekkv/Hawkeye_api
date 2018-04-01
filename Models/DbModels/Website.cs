using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admin_Backend.Models.DbModels
{
    public class Website  : Entity
    {
        public string Category { get; set; }

        public string Cn { get; set; }

        public string Name { get; set; }
    }
}