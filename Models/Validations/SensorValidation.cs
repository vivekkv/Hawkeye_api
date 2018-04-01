using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class SensorValidation: AbstractValidator<Sensor>
    {
        public SensorValidation()
        {
            RuleFor(m => m.SensorName).NotEmpty();
            RuleFor(m => m.SensorType).NotEmpty();
            RuleFor(m => m.Model).NotEmpty();
            RuleFor(m => m.MacAddress).NotEmpty();
            RuleFor(m => m.Status).NotEmpty();
        }
    }
}