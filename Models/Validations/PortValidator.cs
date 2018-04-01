using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class PortValidator: AbstractValidator<Port>
    {
        public PortValidator()
        {
            RuleFor(m => m.PortNumber).NotEmpty();
            RuleFor(m => m.ProtoCol).NotEmpty();
            RuleFor(m => m.Rank).NotEmpty();
            RuleFor(m => m.Service).NotEmpty();
        }
    }
}