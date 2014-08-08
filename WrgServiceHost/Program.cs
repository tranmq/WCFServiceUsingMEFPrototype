using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WrgConfigService.Contracts;
using WrgConfigService.Implementations;

namespace WrgServiceHost
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var sh = new ServiceHost(typeof (ControllerConfigService), new Uri("http://localhost:8080"));
            bool openSucceeded = false;
            try
            {
                ServiceEndpoint se = sh.AddServiceEndpoint(typeof (IControllerConfigService), new WebHttpBinding(), "WrgConfigService");
                se.Behaviors.Add(new WebHttpBehavior());
                sh.Open();
                openSucceeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ServiceHost failed to open {0}", ex);
            }
            finally
            {
                if (! openSucceeded)
                {
                    sh.Abort();
                }
            }

            if (openSucceeded)
            {
                Console.WriteLine("Service is running...");
                foreach (var endpoint in sh.Description.Endpoints)
                {
                    Console.WriteLine("\tAddress: {0}", endpoint.Address.Uri);
                    Console.WriteLine("\t\tContract Name:{0}", endpoint.Contract.Name);
                }
                Console.WriteLine("Press <ENTER> to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(" Service failed to open");
            }

            bool closeSucceeded = false;
            try
            {
                sh.Close();
                closeSucceeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ServiceHost failed to close {0}", ex);
                Console.WriteLine("Press <ENTER> to continue.");
                Console.ReadLine();
            }
            finally
            {
                if (! closeSucceeded)
                {
                    sh.Abort();
                }
            }
        }
    }
}
