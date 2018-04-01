using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace Admin_Backend.Models.DbModels
{
    public class SensorInstallation : Entity
    {
        public int SensorId { get; set; }

        public string Uuid { get; set; }

        public string Status { get; set; }

        public string Customer { get; set; }

        public string Model { get; set; }

        public string Workspace { get; set; }

        public string FirmwareUpdation { get; set; }

        public string SuricataVersion {  get; set; }

        public string Mode { get; set; }

        public string HostName { get; set; }

        public string NetworkType { get; set; }

        public string IpAddres { get; set; }

        public string Gateway { get; set; }

        public string Mask { get; set; }

        public string MacAddress { get; set; }

        public string Notes { get; set; }

        public DateTime InstalledDate { get; set; }

        public DateTime? UnInstalledDate { get; set; }
    }
}