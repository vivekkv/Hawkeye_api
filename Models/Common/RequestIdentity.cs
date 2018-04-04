namespace hawkeye_api.Models.Common
{
    public class RequestIdentity
    {
        public string WorkspaceId { get; set; }

        public string SensorId { get; set; }

        public int StartDate { get; set; }

        public int EndDate { get; set; }

    }
}