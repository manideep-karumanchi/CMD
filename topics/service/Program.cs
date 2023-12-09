using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            TokenProvider token = TokenProvider.CreateSharedAccessSignatureTokenProvider("RootManageSharedAccessKey", "kajrW+Qet1gWfut1cQMntUc7ii2Mie0KNxFw3F3Nbiw=");
            Uri serviceUri = ServiceBusEnvironment.CreateServiceUri("sb", "beccsea", "");
            NamespaceManager mgr = new NamespaceManager(serviceUri, token);
            if (!mgr.TopicExists("DataCollectionTopic"))
                mgr.CreateTopic("DataCollectionTopic");
            Console.WriteLine("Topic Created");
            if (mgr.SubscriptionExists("DataCollectionTopic", "High")) {
                mgr.DeleteSubscription("DataCollectionTopic", "High");
            }
            SqlFilter filter = new SqlFilter("Priority>2");
            mgr.CreateSubscription("DataCollectionTopic", "High", filter);
            Console.WriteLine("High Priority Subscription Created");
            if (mgr.SubscriptionExists("DataCollectionTopic", "Low"))
            {
                mgr.DeleteSubscription("DataCollectionTopic", "Low");
            }
            filter = new SqlFilter("Priority<=2");
            mgr.CreateSubscription("DataCollectionTopic", "Low", filter);
            Console.WriteLine("Low Priority Subscription Created");

            MessagingFactory factory = MessagingFactory.Create(serviceUri, token);
            TopicClient client = factory.CreateTopicClient("DataCollectionTopic");
            for (int i = 0; i <= 5; i++) {
                BrokeredMessage msg = new BrokeredMessage("Message: " + i);
                msg.Properties.Add("Priority", i);
                client.Send(msg);
            }
        }
    }
}
