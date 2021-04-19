using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMvcWebApp.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index()
        {
            // 요약:
            //     Creates a Microsoft.AspNetCore.Mvc.ViewResult object that renders a view to the response.
            // 반환 값:
            //     The created Microsoft.AspNetCore.Mvc.ViewResult object for the response.
            return View();
        }
    }
}
