using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TokenProvider token = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "kajrW+Qet1gWfut1cQMntUc7ii2Mie0KNxFw3F3Nbiw=");
            Uri serviceUri = ServiceBusEnvironment.CreateServiceUri("sb", "beccsea", "");
            MessagingFactory factory = MessagingFactory.Create(serviceUri, token);
            MessageReceiver r1=factory.CreateMessageReceiver("DataCollectionTopic/subscriptions/High");
            BrokeredMessage msg;
            while ((msg=r1.Receive()) != null) {
                Console.WriteLine("Message: " + msg.GetBody<String>() + "\t Priority: " + msg.Properties["Priority"]);
                msg.Complete();
            }
            Console.WriteLine("High Priority Queue Completed");
            r1 = factory.CreateMessageReceiver("DataCollectionTopic/subscriptions/Low");
            while ((msg = r1.Receive()) != null)
            {
                Console.WriteLine("Message: " + msg.GetBody<String>() + "\t Priority: " + msg.Properties["Priority"]);
                msg.Complete();
            }
            Console.WriteLine("Low Priority Queue Completed");
            Console.ReadLine();
        }
    }
}