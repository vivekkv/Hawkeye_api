using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admin_Backend.Models.DbModels
{
    public class IpPage : Entity
    {
        public string Ip { get; set; }

        public string Description { get; set; }
    }
}