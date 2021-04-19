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
        Startup 클래스를 사용하지 않고 서비스 및 요청 처리 파이프라인을 구성하려면 호스트 작성기에서
        ConfigureServices 및 Configure 편의성 메서드를 호출합니다. 
        ConfigureServices 에 대한 여러 호출은 서로 추가합니다. 
        여러 Configure 메서드 호출이 있는 경우 마지막 Configure 호출이 사용됩니다.
        */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
