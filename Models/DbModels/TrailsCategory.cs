using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admin_Backend.Models.DbModels
{
    public class TrailsCategory : Entity
    {
       public string Name { get; set; }
       public int Code { get; set; }
       public int ApplicationCode { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }
       public int Severity { get; set; }
    }
}