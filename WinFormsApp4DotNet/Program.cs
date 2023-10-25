using PostSharp.Patterns.Diagnostics;

namespace WinFormsApp4DotNet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //获取默认的存储库
            log4net.Repository.ILoggerRepository repository = log4net.LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());

            //配置 log4net
            log4net.Config.XmlConfigurator.Configure(repository, new System.IO.FileInfo("log4net.config"));

            //配置 PostSharp Logging 使用 log4net
            LoggingServices.DefaultBackend = new PostSharp.Patterns.Diagnostics.Backends.Log4Net.Log4NetLoggingBackend(repository);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}