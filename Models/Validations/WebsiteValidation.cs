using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class WebsiteValidation: AbstractValidator<Website>
    {
        public WebsiteValidation()
        {
            RuleFor(m => m.Category).NotEmpty();
            RuleFor(m => m.Cn).NotEmpty();
            RuleFor(m => m.Name).NotEmpty();
        }
    }
}