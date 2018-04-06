namespace hawkeye_api.Models.DbModels
{
    public class Resource
    {
        public string CpuUsage { get; set; }

        public string DiskWrite { get; set; }

        public string DiskRead { get; set; }

        public string DiskTransfer { get; set; }

        public string FreeMemory { get; set; }
    }
}