using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System;
using System.IO;

class Program
{
    static async Task Main(string[] args)
    {
        string connectionString = "DefaultEndpointsProtocol=https;AccountName=cloudshell270915878;AccountKey=6rHQ7uLsp7t/ZrxYBoUr8Fjdq9XNlzFNKErOpLtJmRlOO/ih8KVcujjn1U9Nqj1j7z/Uw5ITHxHy+AStDQuvQQ==;EndpointSuffix=core.windows.net";
        string shareName = "myfileshare";
        string fileName = "resume.txt"; // File name in Azure
       string localFilePath = @"D:\SIVA_IN_MAY\AzureBlob\Star.pdf";  // Local file path
        string localDownloadPath = @"D:\SIVA_IN_MAY\"; // Local download path

        // Connect to file share
        //ShareClient share = new ShareClient(connectionString, shareName);
        //await share.CreateIfNotExistsAsync();

        //// Get root directory
        //ShareDirectoryClient rootDir = share.GetRootDirectoryClient();

        //// Upload file
        //ShareFileClient fileClient = rootDir.GetFileClient(fileName);
        //using FileStream uploadStream = File.OpenRead(localFilePath);
        //await fileClient.CreateAsync(uploadStream.Length);
        //await fileClient.UploadAsync(uploadStream);
        //Console.WriteLine("✅ File uploaded to Azure File Share.");

        //// Download file
        //ShareFileDownloadInfo downloadInfo = await fileClient.DownloadAsync();
        //using FileStream downloadStream = File.OpenWrite(localDownloadPath);
        //await downloadInfo.Content.CopyToAsync(downloadStream);
        //Console.WriteLine("✅ File downloaded from Azure File Share.");



        ShareClient share = new ShareClient(connectionString, shareName);
        ShareDirectoryClient rootDir = share.GetRootDirectoryClient();

        // List all files in the root directory
        await foreach (ShareFileItem item in rootDir.GetFilesAndDirectoriesAsync())
        {
            if (!item.IsDirectory)
            {
                string file_Name = item.Name;
                ShareFileClient fileClient = rootDir.GetFileClient(file_Name);

                string localPath = Path.Combine(localDownloadPath, fileName);

                // Download the file
                ShareFileDownloadInfo downloadInfo = await fileClient.DownloadAsync();
                using FileStream fs = File.OpenWrite(localPath);
                await downloadInfo.Content.CopyToAsync(fs);

                Console.WriteLine($"✅ Downloaded: {file_Name}");
            }
        }
    }
}
