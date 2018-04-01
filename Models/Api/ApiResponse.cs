using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Admin_Backend.Models.Api
{
    public class ApiResponse
    { 
        public bool Success { get;set; }

        public string Message { get; set; }

        public dynamic Data { get; set; } 
    }
}