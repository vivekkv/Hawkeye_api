namespace hawkeye_api.Models.DbModels
{
    public class Processor
    {
        public string Name { get; set; }

        public string MaxClockSpeed { get; set; }

        public string ThreadCount { get; set; }

        public string NumberOfCores { get; set; }

        public string AddressWidth { get; set; }
    }
}