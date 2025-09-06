
using Azure;
using Azure.Data.Tables;

namespace AzureBlobStorageDemo.DataModels
{
    public class ResumeLogEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = "Resume";
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public string FileName { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedAt { get; set; }

        public ETag ETag { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }


}

