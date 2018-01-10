using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri serviceUri = ServiceBusEnvironment.CreateServiceUri("sb", "beccsea", String.Empty);
            TokenProvider credentials = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "Oo0sVn9SQkvuUQV3+TeWoPcpw59f/XTjU0gjuHv1++o=");
            MessagingFactory factory = MessagingFactory.Create(serviceUri, credentials);
            QueueClient client = factory.CreateQueueClient("messagesqueue");
            BrokeredMessage msg = client.Receive();
            Console.WriteLine("TID:"+msg.Properties["TID"]+"\t Amount:"+msg.Properties["Amt"]);
            Console.Read();
            msg.Complete();
        }
    }
}
