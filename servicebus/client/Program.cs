using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Client
{
    [ServiceContract]
    interface IProblemSolver
    {
        [OperationContract]
        int add(int a, int b);
    }
    interface IProblemSolverChannel : IProblemSolver, IClientChannel { }
    class Program
    {
        static void Main(string[] args)
        {
            var ch = new ChannelFactory<IProblemSolverChannel>("solverEP");
            var channel = ch.CreateChannel();
            Console.WriteLine(channel.add(10, 20));
            Console.Read();
        }
    }
}
