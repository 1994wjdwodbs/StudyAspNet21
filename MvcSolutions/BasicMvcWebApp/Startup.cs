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
    ASP.NET Core ���� ��Ģ�� ���� Startup ���� �̸��� ������ Startup Ŭ������ ����մϴ�. Startup Ŭ������

        1. ���������� ���� ���� �� �����ϴ� ConfigureServices �޼��带 �����մϴ�. ���񽺴� �� ����� �����ϴ�
        ���� ������ ���� ����Դϴ�. ���񽺴� ConfigureServices ���� ��� �Ǹ� DI(���Ӽ� ����) �Ǵ�
        ApplicationServices�� ���� �� ��ü���� ���˴ϴ�.

        2. ���� ��û ó�� ������������ ����� Configure �޼��尡 ���ԵǾ� �ֽ��ϴ�.
        (ConfigureServices �� Configure �� �� ���� �� ASP.NET Core ��Ÿ�ӿ� ���� ȣ��˴ϴ�.)

     Startup Ŭ������ �Ϲ������� ȣ��Ʈ �ۼ��⿡ WebHostBuilderExtensions.UseStartup<TStartup> �޼��带 ȣ���Ͽ� �����˴ϴ�.
    (Program.cs -> Main �޼ҵ�� ���� ����)

    (�߿�) "Configure �޼��尡 ȣ��� ������ ��κ��� ���񽺸� ����� �� �����ϴ�."
     */
    public class Startup
    {
        /*
        �ۿ��� �پ��� ȯ��(��: StartupDevelopment )�� ���� ������ Startup Ŭ������ �����ϸ� ��Ÿ�ӿ� ������
        Startup Ŭ������ ���õ˴ϴ�. �̸� ���̻簡 ���� ȯ��� ��ġ�ϴ� Ŭ������ �켱 ������ �ο��˴ϴ�. ����
        ���� ȯ�濡�� ����ǰ� Startup Ŭ���� �� StartupDevelopment Ŭ���� ��θ� �����ϴ� ���
        StartupDevelopment Ŭ������ ���˴ϴ�. �ڼ��� ������ ���� ȯ�� ����� �����ϼ���.
         */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // (�߿�) "Configure �޼��尡 ȣ��� ������ ��κ��� ���񽺸� ����� �� �����ϴ�."
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /*
        ���� �����Դϴ�.
        Configure �޼��� ���� ȣ��Ʈ�� ���� ȣ��Ǿ� ���� ���񽺸� �����մϴ�.
        ���⼭ ���� �ɼ��� ��Ģ�� ���� �����˴ϴ�.
        ȣ��Ʈ�� Startup �޼��尡 ȣ��Ǳ� ���� �Ϻ� ���񽺸� ������ �� �ֽ��ϴ�. �ڼ��� ������ ȣ��Ʈ�� �����ϼ���.
        
        �������� ������ �ʿ��� ����� ��� IServiceCollection�� Add{Service} Ȯ�� �޼��尡 �ֽ��ϴ�. ���� ���
        Add DbContext, Add DefaultIdentity, Add EntityFrameworkStores �� AddRazorPages�� �ֽ��ϴ�.
        */
        public void ConfigureServices(IServiceCollection services)
        { // ���������� ���� ���� �� ����
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*
        Configure �޼���� ���� HTTP ��û�� �����ϴ� ����� �����ϴ� �� ���˴ϴ�. 
        ��û ������������ �̵���� ���� ��Ҹ� IApplicationBuilder �ν��Ͻ��� �߰��Ͽ� �����˴ϴ�. 
        IApplicationBuilder �� Configure �޼��忡 ����� �� ������ ���� �����̳ʿ� ��ϵ��� �ʽ��ϴ�. 
        ȣ������ IApplicationBuilder �� ����� Configure�� ���� �����մϴ�.

        �̵����
            �̵����� � ü���� �ش� � ü������ ����Ǵ� ���� ���α׷� ���̿� �����ϴ� ����Ʈ�����Դϴ�. 
            �⺻������ ������ ��ȯ �������� ����ϴ� �̵����� �л� ���� ���α׷��� ��� �� ������ ������ �����ϰ� �մϴ�. 
            �����Ϳ� �����ͺ��̽��� "������" ���̸� ���� ����� �� �ֵ��� �� ���� ���� ���α׷��� �Բ� �����ϱ� ������ ����̶�� �մϴ�. 
            �̵��� ����ϸ� ����ڰ� �� ���������� ����� �����ϰų� �� ������ ������� �������� ������� ���� �� �������� ��ȯ�ϵ��� ��û�� �� �ֽ��ϴ�.

            �Ϲ����� �̵���� ���δ� �����ͺ��̽� �̵����, ���ø����̼� ���� �̵����, �޽��� ���� �̵����, �� �̵���� �� Ʈ����� ó�� ����Ͱ� �ֽ��ϴ�. 
            �� ���α׷��� �Ϲ������� SOAP(Simple Object Access Protocol), �� ����, REST(Representational State Transfer) �� JSON(JavaScript Object Notation)�� ���� 
            �޽�¡ �����ӿ�ũ�� ����Ͽ� ���� �ٸ� ���� ���α׷��� ����� �� �ֵ��� �޽��� ���񽺸� �����մϴ�. 
            ��� �̵��� ��� ����� ���������� ȸ�簡 ����ϱ�� ������ ������ ��� ���� ���񽺿� ����ؾ� �� ���� ���Ŀ� ���� �ٸ��ϴ�. 
            ���⿡�� ���� ����, Ʈ����� ����, �޽��� ť, ���� ���α׷� ����, �� ���� �� ���͸��� ���Ե� �� �ֽ��ϴ�. 
            �̵����� �����͸� �յڷ� ������ �ʰ� �ǽð����� �߻��ϴ� �۾����� �л� ó������ ����� �� �ֽ��ϴ�.

        IApplicationBuilder
            Defines a class that provides the mechanisms to configure an application's request pipeline.

        IWebHostEnvironment
            Provides information about the web hosting environment an application is running in.
        */
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { // ���� ��û ó�� ������������ ����
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
            { // ���� : ��Ʈ�ѷ��� Views -> Home -> index.cshtml ���
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
