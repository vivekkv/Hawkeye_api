using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admin_Backend.Models.DbModels
{
    public class Port : Entity
    {
       public string Service { get; set; }
       public int PortNumber { get; set; }
       public string ProtoCol { get; set; }
       public int Rank { get; set; }
    }
}