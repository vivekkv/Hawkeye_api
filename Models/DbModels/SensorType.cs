using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Admin_Backend.Models.DbModels
{
    public class SensorType  : Entity
    {
        public string SensorTypeName { get; set; }
    }
}