using System;

namespace hawkeye_api.Models.DbModels
{
    public class Resource
    {

        public Resource() {

            this.CpuPercentage = Convert.ToInt32(this.CpuUsage);
        }

        public int CpuPercentage {get;set;}

        public string CpuUsage { get; set; }

        public string DiskWrite { get; set; }

        public string DiskRead { get; set; }

        public string DiskTransfer { get; set; }

        public string FreeMemory { get; set; }

        public string sensor_uuid {get;set;}
    }
}