using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.RequestModals
{
    public class UserLoginMoal
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}