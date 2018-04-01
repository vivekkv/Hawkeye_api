using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;
using FluentValidation;

namespace Admin_Backend.Models.Validations
{
    public class SensorInstallationDetailValidation: AbstractValidator<SensorInstallation>
    {
        public SensorInstallationDetailValidation()
        {
            RuleFor(m => m.Customer).NotEmpty();
            RuleFor(m => m.FirmwareUpdation).NotEmpty();
            RuleFor(m => m.Gateway).NotEmpty();
            RuleFor(m => m.InstalledDate).NotEmpty();
            RuleFor(m => m.IpAddres).NotEmpty();
            RuleFor(m => m.MacAddress).NotEmpty();
            RuleFor(m => m.Mask).NotEmpty();
            RuleFor(m => m.Model).NotEmpty();
            RuleFor(m => m.Mode).NotEmpty();
            RuleFor(m => m.NetworkType).NotEmpty();
            RuleFor(m => m.SensorId).NotEmpty();
            RuleFor(m => m.SuricataVersion).NotEmpty();
            //RuleFor(m => m.UnInstalledDate).NotEmpty();
            RuleFor(m => m.Uuid).NotEmpty();
            RuleFor(m => m.Workspace).NotEmpty();
        }
    }
}