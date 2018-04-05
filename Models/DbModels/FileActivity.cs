namespace hawkeye_api.Models.DbModels
{
    public class FileActivity
    {
        public int LogTime { get; set; }

        public string UserName { get; set; }

        public string Action { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }
    }
}