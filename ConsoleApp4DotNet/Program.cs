public class Program
{
    // 定义一个静态 logger 变量，其引用名为 "Program" 的 Logger 实例
    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

    static void Main(string[] args)
    {
        // 使用 XmlConfigurator 直接读取 XML 文件并使用它来配置 log4net
        log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));

        log.Debug("开始调试");
        log.Info("Entering application.");
        log.Warn("警告");
        log.Error("错误", new Exception("异常信息"));
        log.Fatal("致命错误", new Exception("异常信息"));
    }
}