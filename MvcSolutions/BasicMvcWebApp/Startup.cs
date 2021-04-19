using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMvcWebApp
{
    /*
    ASP.NET Core 앱은 규칙에 따라 Startup 으로 이름이 지정된 Startup 클래스를 사용합니다. Startup 클래스는

        1. 선택적으로 앱의 서비스 를 구성하는 ConfigureServices 메서드를 포함합니다. 서비스는 앱 기능을 제공하는
        재사용 가능한 구성 요소입니다. 서비스는 ConfigureServices 에서 등록 되며 DI(종속성 주입) 또는
        ApplicationServices를 통해 앱 전체에서 사용됩니다.

        2. 앱의 요청 처리 파이프라인을 만드는 Configure 메서드가 포함되어 있습니다.
        (ConfigureServices 및 Configure 는 앱 시작 시 ASP.NET Core 런타임에 의해 호출됩니다.)

     Startup 클래스는 일반적으로 호스트 작성기에 WebHostBuilderExtensions.UseStartup<TStartup> 메서드를 호출하여 지정됩니다.
    (Program.cs -> Main 메소드로 최초 실행)

    (중요) "Configure 메서드가 호출될 때까지 대부분의 서비스를 사용할 수 없습니다."
     */
    public class Startup
    {
        /*
        앱에서 다양한 환경(예: StartupDevelopment )에 대해 별도의 Startup 클래스를 정의하면 런타임에 적절한
        Startup 클래스가 선택됩니다. 이름 접미사가 현재 환경과 일치하는 클래스에 우선 순위가 부여됩니다. 앱이
        개발 환경에서 실행되고 Startup 클래스 및 StartupDevelopment 클래스 모두를 포함하는 경우
        StartupDevelopment 클래스가 사용됩니다. 자세한 내용은 여러 환경 사용을 참조하세요.
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // (중요) "Configure 메서드가 호출될 때까지 대부분의 서비스를 사용할 수 없습니다."
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /*
        선택 사항입니다.
        Configure 메서드 전에 호스트에 의해 호출되어 앱의 서비스를 구성합니다.
        여기서 구성 옵션이 규칙에 의해 설정됩니다.
        호스트는 Startup 메서드가 호출되기 전에 일부 서비스를 구성할 수 있습니다. 자세한 내용은 호스트를 참조하세요.
        
        실질적인 설정이 필요한 기능의 경우 IServiceCollection에 Add{Service} 확장 메서드가 있습니다. 예를 들어
        Add DbContext, Add DefaultIdentity, Add EntityFrameworkStores 및 AddRazorPages가 있습니다.
        */
        public void ConfigureServices(IServiceCollection services)
        { // 선택적으로 앱의 서비스 를 구성
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*
        Configure 메서드는 앱이 HTTP 요청에 응답하는 방식을 지정하는 데 사용됩니다. 
        요청 파이프라인은 미들웨어 구성 요소를 IApplicationBuilder 인스턴스에 추가하여 구성됩니다. 
        IApplicationBuilder 는 Configure 메서드에 사용할 수 있지만 서비스 컨테이너에 등록되지 않습니다. 
        호스팅이 IApplicationBuilder 를 만들고 Configure에 직접 전달합니다.

        미들웨어
            미들웨어는 운영 체제와 해당 운영 체제에서 실행되는 응용 프로그램 사이에 존재하는 소프트웨어입니다. 
            기본적으로 숨겨진 변환 계층으로 기능하는 미들웨어는 분산 응용 프로그램의 통신 및 데이터 관리를 가능하게 합니다. 
            데이터와 데이터베이스가 "파이프" 사이를 쉽게 통과할 수 있도록 두 가지 응용 프로그램을 함께 연결하기 때문에 배관이라고도 합니다. 
            미들웨어를 사용하면 사용자가 웹 브라우저에서 양식을 제출하거나 웹 서버가 사용자의 프로필을 기반으로 동적 웹 페이지를 반환하도록 요청할 수 있습니다.

            일반적인 미들웨어 예로는 데이터베이스 미들웨어, 애플리케이션 서버 미들웨어, 메시지 지향 미들웨어, 웹 미들웨어 및 트랜잭션 처리 모니터가 있습니다. 
            각 프로그램은 일반적으로 SOAP(Simple Object Access Protocol), 웹 서비스, REST(Representational State Transfer) 및 JSON(JavaScript Object Notation)과 같은 
            메시징 프레임워크를 사용하여 서로 다른 응용 프로그램이 통신할 수 있도록 메시지 서비스를 제공합니다. 
            모든 미들웨어가 통신 기능을 수행하지만 회사가 사용하기로 선택한 형식은 사용 중인 서비스와 통신해야 할 정보 형식에 따라 다릅니다. 
            여기에는 보안 인증, 트랜잭션 관리, 메시지 큐, 응용 프로그램 서버, 웹 서버 및 디렉터리가 포함될 수 있습니다. 
            미들웨어는 데이터를 앞뒤로 보내지 않고 실시간으로 발생하는 작업으로 분산 처리에도 사용할 수 있습니다.

        IApplicationBuilder
            Defines a class that provides the mechanisms to configure an application's request pipeline.

        IWebHostEnvironment
            Provides information about the web hosting environment an application is running in.
        */
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { // 앱의 요청 처리 파이프라인을 만듬
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { // 시작 : 컨트롤러가 Views -> Home -> index.cshtml 출력
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
