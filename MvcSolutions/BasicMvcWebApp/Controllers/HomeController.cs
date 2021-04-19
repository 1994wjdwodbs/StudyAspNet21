using BasicMvcWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMvcWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // "XXXController <-> Views/XXX 폴더와 매핑됨"
        // "XXXController : XXX란 이름으로 동작하는 컨트롤러"
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // View -> Home -> Index.cshtml (뷰에 Index.cshtml 전달)
        public IActionResult Index()
        {
            // 요약:
            //     Creates a Microsoft.AspNetCore.Mvc.ViewResult object that renders a view to the response.
            // 반환 값:
            //     The created Microsoft.AspNetCore.Mvc.ViewResult object for the response.
            return View();
        }

        // View -> Home -> Privacy.cshtml (뷰에 Privacy.cshtml 전달)
        public IActionResult Privacy()
        {
            // 요약:
            //     Creates a Microsoft.AspNetCore.Mvc.ViewResult object that renders a view to the response.
            // 반환 값:
            //     The created Microsoft.AspNetCore.Mvc.ViewResult object for the response.
            return View();
        }

        // 우리가 만든 임시 Action (뷰에 Contact.cshtml 전달) 
        public IActionResult Contact()
        {
            // 요약:
            //     Creates a Microsoft.AspNetCore.Mvc.ViewResult object that renders a view to the response.
            // 반환 값:
            //     The created Microsoft.AspNetCore.Mvc.ViewResult object for the response.
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
