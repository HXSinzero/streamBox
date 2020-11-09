using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using System;
using System.Threading;
using System.Windows.Forms;

namespace WMProjectHost
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        //[STAThread]
        static void Main()
        {
            LogManager.LogFactory = (ILogFactory)new NLogFactory();
            ILog logger = LogManager.GetLogger(typeof(Program));
            try
            {
                string appname = "WMProjectHost";
                bool createdNew;
                string msg = null;
                using (new Mutex(true, appname, out createdNew))
                {
                    if (createdNew)
                    {
                        try
                        {
                            HelperApp helperApp = new HelperApp();
                            helperApp.Start();
                            msg = appname + "服务已启动……";
                            logger.Info(msg);
                            Console.WriteLine(msg);

                            //Application.EnableVisualStyles();
                            //Application.SetCompatibleTextRenderingDefault(false);
                            //Application.Run(new Form1());

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
                    else
                    {
                        msg = appname + "应用程序已经在运行中!";
                        logger.Info(msg);
                        logger.Error(msg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                logger.Info(".........");
                logger.Info("......");
                logger.Info("...");
            }
        }
    }
}
