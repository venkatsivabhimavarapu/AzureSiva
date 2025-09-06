
//using Azure.Data.Tables;
//using Azure.Storage.Blobs;
//using Azure.Storage.Queues;
//using AzureBlobStorageDemo.DataModels;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//class Program
//{


//    static async Task Main(string[] args)
//    {

//        string connectionString = "DefaultEndpointsProtocol=https;AccountName=cloudshell270915878;AccountKey=6rHQ7uLsp7t/ZrxYBoUr8Fjdq9XNlzFNKErOpLtJmRlOO/ih8KVcujjn1U9Nqj1j7z/Uw5ITHxHy+AStDQuvQQ==;EndpointSuffix=core.windows.net";
//        string containerName = "resumes";
//        string tableName = "ResumeLog";
//        string queueName = "resumequeue";
//        Console.Write("Enter your name: ");
//        string uploadedBy = Console.ReadLine();

//        string filePath = @"D:\SIVA_IN_MAY\AzureBlob\siva_resume.pdf";
//        string blobName = Path.GetFileName(filePath);

//        // Upload to Blob
//        var blobService = new BlobServiceClient(connectionString);
//        var containerClient = blobService.GetBlobContainerClient(containerName);
//        await containerClient.CreateIfNotExistsAsync();
//        var blobClient = containerClient.GetBlobClient(blobName);

//        using FileStream fileStream = File.OpenRead(filePath);
//        await blobClient.UploadAsync(fileStream, overwrite: true);
//        Console.WriteLine("✅ Uploaded to Blob");

//        // Log in Table Storage
//        var tableService = new TableServiceClient(connectionString);
//        var tableClient = tableService.GetTableClient(tableName);
//        await tableClient.CreateIfNotExistsAsync();

//        var logEntity = new ResumeLogEntity
//        {
//            FileName = blobName,
//            UploadedBy = uploadedBy,
//            UploadedAt = DateTime.UtcNow
//        };

//        await tableClient.AddEntityAsync(logEntity);
//        Console.WriteLine("📒 Logged in Table Storage");

//        // Send message to Queue
//        var queueClient = new QueueClient(connectionString, queueName);
//        await queueClient.CreateIfNotExistsAsync();
//        await queueClient.SendMessageAsync($"Resume uploaded by {uploadedBy}: {blobName}");
//        Console.WriteLine("📬 Message added to Queue");
//    }
//}
