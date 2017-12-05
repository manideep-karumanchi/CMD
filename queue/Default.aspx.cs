using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace QueueWR
{
    public partial class Default : System.Web.UI.Page
    {
        CloudQueue queue;
        protected void Page_Load(object sender, EventArgs e)
        {
            CloudStorageAccount csa = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("QueueCS"));
            CloudQueueClient client = csa.CreateCloudQueueClient();
            queue = client.GetQueueReference("mail");
            queue.CreateIfNotExists();
        }

        protected void sumbmit_Click(object sender, EventArgs e)
        {
            String id = mid.Text;
            String s = sub.Text;
            String m = msg.Text;
            CloudQueueMessage qmsg = new CloudQueueMessage(id+","+s+","+m);
            queue.AddMessage(qmsg);
        }
    }
}