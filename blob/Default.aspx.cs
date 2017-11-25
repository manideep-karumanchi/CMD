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
    public partial class Default : System.Web.UI.Page
    {
        CloudBlockBlob blobref;
        protected void Page_Load(object sender, EventArgs e)
        {
            CloudStorageAccount csa = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=beccsea;AccountKey=l3iT1cck95e8qVhvqgjqoPhhOjQ09Ybxd3TlZUAKKGTeP4DIYrxO2DfOzntqF76A5T0gffTWNgZ5UV9NEOWSxQ==;EndpointSuffix=core.windows.net");
            CloudBlobClient cbc = csa.CreateCloudBlobClient();
            CloudBlobContainer container = cbc.GetContainerReference("container");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions {PublicAccess=BlobContainerPublicAccessType.Blob });
            blobref=container.GetBlockBlobReference("01.jpg");
        }

        protected void UBtn_Click(object sender, EventArgs e)
        {
            blobref.UploadFromStream(System.IO.File.OpenRead(@"D:\collegedata\mic\azure registrations-15-04-2016\01.jpg"));
        }

        protected void DBtn_Click(object sender, EventArgs e)
        {
            blobref.DownloadToStream(System.IO.File.OpenWrite(@"D:\collegedata\mic\azure registrations-15-04-2016\test01.jpg"));
        }
    }
}