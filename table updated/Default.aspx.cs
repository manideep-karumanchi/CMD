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
            TableQuery<ContactEntity> query = new TableQuery<ContactEntity>();
            ContactsGrid.DataSource = table.ExecuteQuery(query);
            ContactsGrid.DataBind();

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

        protected void ContactsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            InsertTable.Visible = false;
            ContactsGrid.Visible = false;
            editfs.Visible = true;
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = ContactsGrid.Rows[index];
            EFNTB.Text = selectedRow.Cells[0].Text;
            ELNTB.Text = selectedRow.Cells[1].Text;
            ECNTB.Text = selectedRow.Cells[2].Text;
            ECTTB.Text = selectedRow.Cells[3].Text;   
        }

        protected void RB_Click(object sender, EventArgs e)
        {
            TableOperation retrieveOp = TableOperation.Retrieve<ContactEntity>(ECTTB.Text, ECNTB.Text);
            TableResult retrievedresult = table.Execute(retrieveOp);
            ContactEntity updaterecord = (ContactEntity)retrievedresult.Result;
            updaterecord.FirstName = EFNTB.Text;
            updaterecord.LastName = ELNTB.Text;
            table.Execute(TableOperation.InsertOrReplace(updaterecord));
            Response.Redirect("Default.aspx");
        }

        protected void DB_Click(object sender, EventArgs e)
        {
            TableOperation retrieveOp = TableOperation.Retrieve<ContactEntity>(ECTTB.Text, ECNTB.Text);
            TableResult retrievedresult = table.Execute(retrieveOp);
            ContactEntity updaterecord = (ContactEntity)retrievedresult.Result;
            table.Execute(TableOperation.Delete(updaterecord));
            Response.Redirect("Default.aspx");
        }
    }
}