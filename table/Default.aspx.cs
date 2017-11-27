using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableRole
{
    class ContactEntity : TableEntity {
        public String FirstName { get; set;}
        public String LastName { get; set; }
        public ContactEntity() { }
        public ContactEntity(String fn, String ln, String cn, String ct) {
            FirstName = fn;
            LastName = ln;
            PartitionKey = ct;
            RowKey = cn;
        }
    }
    public partial class Default : System.Web.UI.Page
    {
        CloudTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            CloudStorageAccount csa = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            CloudTableClient client = csa.CreateCloudTableClient();
            table = client.GetTableReference("contactbook");
            table.CreateIfNotExists();

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            String fn = FNTB.Text;
            String ln = LNTB.Text;
            String cn = CNTB.Text;
            String ct = CTDL.SelectedValue;
            ContactEntity ce = new ContactEntity(fn,ln,cn,ct);
            TableOperation insertOperation = TableOperation.Insert(ce);
            table.Execute(insertOperation);
        }
    }
}