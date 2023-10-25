using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4DotNetFramework
{
    internal class Program
    {
        // 定义一个静态 logger 变量，其引用名为 "Program" 的 Logger 实例
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            log.Debug("开始调试");
            log.Info("Entering application.");
            log.Warn("警告");
            log.Error("错误", new Exception("异常信息"));
            log.Fatal("致命错误", new Exception("异常信息"));
            Console.ReadKey();
        }
    }
}
