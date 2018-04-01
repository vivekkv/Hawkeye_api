using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class UsersValidation: AbstractValidator<Users>
    {
        public UsersValidation()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
            RuleFor(m => m.RoleId).NotEmpty();
            RuleFor(m => m.Salt).NotEmpty();
            RuleFor(m => m.UserName).NotEmpty();
        }
    }
}