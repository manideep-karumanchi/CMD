using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace blob
{
    public partial class PhotoBucket : System.Web.UI.Page
    {
        CloudBlobContainer container;
        protected void Page_Load(object sender, EventArgs e)
        {
            CloudStorageAccount csa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageCS"));
            CloudBlobClient client = csa.CreateCloudBlobClient();
            container = client.GetContainerReference("photobucket");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
            ImgList.DataSource = container.ListBlobs();
            ImgList.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference(ImgSelector.FileName);
            blob.UploadFromStream(ImgSelector.FileContent);
        }
    }
}