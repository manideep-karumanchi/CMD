using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Description;
using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri serviceUri = ServiceBusEnvironment.CreateServiceUri("sb", "beccsea", String.Empty);
            TokenProvider credentials = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "Oo0sVn9SQkvuUQV3+TeWoPcpw59f/XTjU0gjuHv1++o=");
            NamespaceManager nameSpaceManager = new NamespaceManager(serviceUri,credentials);
            if(!nameSpaceManager.QueueExists("messagesqueue"))
                nameSpaceManager.CreateQueue("messagesqueue");
            MessagingFactory factory = MessagingFactory.Create(serviceUri, credentials);
            QueueClient client = factory.CreateQueueClient("messagesqueue");
            BrokeredMessage msg = new BrokeredMessage();
            msg.Properties.Add("TID",100);
            msg.Properties.Add("Amt",10000);
            client.Send(msg);
            Console.WriteLine("Message Added");
            Console.Read();

        }
    }
}
