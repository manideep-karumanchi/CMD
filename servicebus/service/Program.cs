using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Service
{
    [ServiceContract]
    interface IProblemSolver {
        [OperationContract]
        int add(int a, int b);
    }
    class ProblemSolver : IProblemSolver {
        public int add(int a, int b) {
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(ProblemSolver));
            sh.Open();
            Console.WriteLine("Press ENTER to stop");
            Console.Read();
            sh.Close();
        }
    }
}
