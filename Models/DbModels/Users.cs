using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admin_Backend.Models.DbModels
{
    public class Users  : Entity
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Salt { get; set;}

        public int RoleId { get; set; }
    }
}