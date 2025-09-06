//using Azure.Storage.Blobs;
//using Azure.Storage.Blobs.Models;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        string connectionString = "DefaultEndpointsProtocol=https;AccountName=cloudshell270915878;AccountKey=6rHQ7uLsp7t/ZrxYBoUr8Fjdq9XNlzFNKErOpLtJmRlOO/ih8KVcujjn1U9Nqj1j7z/Uw5ITHxHy+AStDQuvQQ==;EndpointSuffix=core.windows.net";
//        string containerName = "mycontainer";
//        string localFilePath = @"D:\SIVA_IN_MAY\AzureBlob\siva.jpg";  // Local file path
//        string blobName = "siva.jpg";  // File name in Azure
//        string localFolderPath = @"D:\SIVA_IN_MAY\"; // Save downloaded file

//        try
//        {
//            // Create client and container if it doesn't exist
//            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
//            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
//            await containerClient.CreateIfNotExistsAsync();

//            BlobClient blobClient = containerClient.GetBlobClient(blobName);

//            // Upload the file
//            //using FileStream uploadFileStream = File.OpenRead(localFilePath);
//            //await blobClient.UploadAsync(uploadFileStream, overwrite: true);

//            //Console.WriteLine("✅ Upload successful! Blob URL:");
//            //Console.WriteLine(blobClient.Uri.AbsoluteUri);


//            // Download the file
//            if (!Directory.Exists(localFolderPath))
//                Directory.CreateDirectory(localFolderPath);

//            Console.WriteLine("📦 Downloading blobs from container...");

//            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
//            {
//                string blob_Name = blobItem.Name;
//                string local_FilePath = Path.Combine(localFolderPath, blobName);
//                using FileStream downloadFileStream = File.OpenWrite(local_FilePath);
//                await blobClient.DownloadToAsync(downloadFileStream);

//                Console.WriteLine($"✅ Downloaded: {blobName} to {local_FilePath}");
//            }

//            Console.WriteLine("🎉 All blobs downloaded successfully!");

//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine("❌ Upload failed: " + ex.Message);
//        }
//    }
//}



//using Azure.Storage.Blobs;
//using Azure.Storage.Blobs.Models;
//using Azure.Storage.Sas;
//using Azure.Storage.Queues;
//using System;
//using System.IO;
//using System.Threading.Tasks;

//class Program
//{
//    static string connectionString = "DefaultEndpointsProtocol=https;AccountName=cloudshell270915878;AccountKey=6rHQ7uLsp7t/ZrxYBoUr8Fjdq9XNlzFNKErOpLtJmRlOO/ih8KVcujjn1U9Nqj1j7z/Uw5ITHxHy+AStDQuvQQ==;EndpointSuffix=core.windows.net";

//    static string containerName = "mycontainer";

//    static async Task Main(string[] args)
//    {
//        Console.WriteLine("Azure Storage Demo");
//        Console.WriteLine("1. Upload");
//        Console.WriteLine("2. Download");
//        Console.WriteLine("3. List Blobs");
//        Console.WriteLine("4. Generate SAS Link");
//        Console.WriteLine("5. Delete Blob");
//        Console.Write("Choose option: ");
//        var choice = Console.ReadLine();

//        switch (choice)
//        {
//            case "1": await UploadFile(); break;
//            case "2": await DownloadFile(); break;
//            case "3": await ListBlobs(); break;
//            case "4": await GenerateSas(); break;
//            case "5": await DeleteBlob(); break;
//            default: Console.WriteLine("Invalid option."); break;
//        }
//    }

//    static async Task UploadFile()
//    {
//        string filePath = @"D:\SIVA_IN_MAY\AzureBlob\siva.jpg";
//        string blobName = Path.GetFileName(filePath);

//        BlobClient blobClient = new BlobContainerClient(connectionString, containerName).GetBlobClient(blobName);

//        using FileStream stream = File.OpenRead(filePath);
//        await blobClient.UploadAsync(stream, overwrite: true);
//        Console.WriteLine("✅ File uploaded.");
//    }

//    static async Task DownloadFile()
//    {
//        string blobName = "siva.jpg";
//        string downloadPath = @"D:\SIVA_IN_MAY\DownloadedFiles\" + blobName;

//        Directory.CreateDirectory(Path.GetDirectoryName(downloadPath)!);

//        BlobClient blobClient = new BlobContainerClient(connectionString, containerName).GetBlobClient(blobName);
//        using FileStream file = File.OpenWrite(downloadPath);
//        await blobClient.DownloadToAsync(file);
//        Console.WriteLine($"✅ Downloaded to: {downloadPath}");
//    }

//    static async Task ListBlobs()
//    {
//        BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);
//        await foreach (BlobItem blob in containerClient.GetBlobsAsync())
//        {
//            Console.WriteLine($"📁 Blob: {blob.Name}");
//        }
//    }

//    static async Task GenerateSas()
//    {
//        string blobName = "siva.jpg";
//        BlobClient blobClient = new BlobContainerClient(connectionString, containerName).GetBlobClient(blobName);

//        if (blobClient.CanGenerateSasUri)
//        {
//            BlobSasBuilder sas = new BlobSasBuilder
//            {
//                BlobContainerName = containerName,
//                BlobName = blobName,
//                Resource = "b",
//                ExpiresOn = DateTimeOffset.UtcNow.AddHours(1)
//            };
//            sas.SetPermissions(BlobSasPermissions.Read);

//            Uri sasUri = blobClient.GenerateSasUri(sas);
//            Console.WriteLine("🔐 SAS URL: " + sasUri);
//https://cloudshell270915878.blob.core.windows.net/mycontainer/siva.jpg?sv=2025-05-05&se=2025-06-12T11%3A10%3A51Z&sr=b&sp=r&sig=3WDs6Av9qGIASeDq8eED6xk4hbIxOyZ7m86QJZcrz1k%3D
//        }
//        else
//        {
//            Console.WriteLine("❌ SAS not supported with current credentials.");
//        }
//    }

//    static async Task DeleteBlob()
//    {
//        string blobName = "siva.jpg";
//        BlobClient blobClient = new BlobContainerClient(connectionString, containerName).GetBlobClient(blobName);
//        await blobClient.DeleteIfExistsAsync();
//        Console.WriteLine("🗑️ Blob deleted.");
//    }
//}
