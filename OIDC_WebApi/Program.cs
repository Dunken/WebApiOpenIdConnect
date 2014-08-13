using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OIDC_WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Debugger.Break();
            try
            {
                var options = new StartOptions();
                options.Urls.Add(string.Format("http://{0}:{1}", "localhost", 8080));
                options.Urls.Add(string.Format("http://{0}:{1}", Environment.MachineName, 8080));

                options.Urls.Add(string.Format("https://{0}:{1}", "localhost", 8443));
                options.Urls.Add(string.Format("https://{0}:{1}", Environment.MachineName, 8443));

                using (WebApp.Start<Startup>(options))
                {
                    var wait = new ManualResetEvent(false);
                    wait.WaitOne();
                }
            }
            catch (Exception ex)
            {
            }
            Console.ReadLine();
        }
    }
}
