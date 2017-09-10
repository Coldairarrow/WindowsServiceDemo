using Coldairarrow.Util.WindowsService;
using System;

namespace WindowsServiceTest
{
    class Program
    {
        public static void Main(string[] argc)
        {
            //创建服务容器，第一个参数为指定服务名，第二个参数为主函数入口的参数argc
            WindowsServiceContainer serviceContainer = new WindowsServiceContainer("A_Test_Service", argc);

            //服务启动时执行的事件，即可以看做控制台的主函数Main即可
            serviceContainer.HandleOnStart = new Action<string[]>(args =>
            {
                //可以在这里添加你需要服务干的事情，比如创建Socket通讯，Wcf服务，balabala.........
                //让它在后台默默地工作把~~~~~~~~~~
            });

            //处理日志的事件
            serviceContainer.HandleLog = new Action<string>(log =>
            {
                Console.WriteLine(log);
            });

            //处理异常的事件
            serviceContainer.HandleException = new Action<Exception>(ex =>
            {
                Console.WriteLine(ex.Message);
            });

            //开始运行服务
            serviceContainer.Start();
        }
    }
}
