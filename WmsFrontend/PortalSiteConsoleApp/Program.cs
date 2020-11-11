using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSiteConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HelperApp helperApp = new HelperApp();
            ILog logger = LogManager.GetLogger(typeof(Program));

            try
            {
                helperApp.Start();

                string msg = "PortalSiteConsoleApp服务已启动……";
                logger.Info(msg);
                Console.WriteLine(msg);

                ConsoleKeyInfo cki;
                // Prevent example from ending if CTL+C is pressed.
                Console.TreatControlCAsInput = true;

                Console.WriteLine("Press the CTL + C to quit: \n");
                do
                {
                    cki = Console.ReadKey();
                    //Console.Write(" --- You pressed ");
                    if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
                    //Console.WriteLine(cki.Key.ToString());
                } while (cki.Key != ConsoleKey.C);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
