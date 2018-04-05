namespace hawkeye_api.Models.DbModels
{
    public class BandWidth
    {
        public int Event_Timestamp { get; set; }

        public string BytesReceived { get; set; }

        public string BytesSent { get; set; }

        public string Speed { get; set; }

        public int TimeStamp { get; set; }
    }
}