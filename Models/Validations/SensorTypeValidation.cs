using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class SensorTypeValidation: AbstractValidator<SensorType>
    {
        public SensorTypeValidation()
        {
            RuleFor(m => m.SensorTypeName).NotEmpty();
        }
    }
}