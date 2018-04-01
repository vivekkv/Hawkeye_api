using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class RuleEditorValidation: AbstractValidator<RuleEditor>
    {
        public RuleEditorValidation()
        {
            RuleFor(m => m.Summary).NotEmpty();
            RuleFor(m => m.ModuleId).NotEmpty();
            RuleFor(m => m.Weight).NotEmpty();
        }
    }
}