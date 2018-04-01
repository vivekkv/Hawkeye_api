using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Admin_Backend.Models.DbModels
{
    public class Sensor : Entity
    {
        public string SensorName { get; set; }

        public string SensorType { get; set; }

        public string Model { get; set; }

        public string MacAddress { get; set; } 

        public DateTime AddedDate { get; set; }

        public string Status { get; set; }
    }
}