using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMvcWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /*
        Startup Ŭ������ ������� �ʰ� ���� �� ��û ó�� ������������ �����Ϸ��� ȣ��Ʈ �ۼ��⿡��
        ConfigureServices �� Configure ���Ǽ� �޼��带 ȣ���մϴ�. 
        ConfigureServices �� ���� ���� ȣ���� ���� �߰��մϴ�. 
        ���� Configure �޼��� ȣ���� �ִ� ��� ������ Configure ȣ���� ���˴ϴ�.
        */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
