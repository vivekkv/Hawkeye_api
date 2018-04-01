using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class IpPageValidation: AbstractValidator<IpPage>
    {
        public IpPageValidation()
        {
            RuleFor(m => m.Ip).NotEmpty();
        }
    }
}