using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class TrailsCategoryValidator : AbstractValidator<TrailsCategory>
    {
        public TrailsCategoryValidator()
        {
            RuleFor(m => m.ApplicationCode).NotEmpty();
            RuleFor(m => m.Code).NotEmpty();
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Severity).NotEmpty();
        }
    }
}