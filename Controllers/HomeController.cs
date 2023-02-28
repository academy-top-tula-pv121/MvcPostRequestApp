using Microsoft.AspNetCore.Mvc;
using MvcPostRequestApp.Models;
using System.Diagnostics;

namespace MvcPostRequestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task Index()
        {
            string htmlStr = @"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"" />
    <title>Form</title>
</head>
<body>
    <form method=""post"">
        <p>
            <label>Name:</label><br />
            <input name=""name"" />
        </p>
        <p>
            <label>Age:</label><br />
            <input type=""number"" name=""age"" />
        </p>
<p>
            <label>Skills</label>
            <input name=""[0]"" /><br />
            <input name=""[2]"" /><br />
            <input name=""[1]"" /><br />
        </p>
        <input type=""submit"" value=""Send"" />
    </form>
</body>
</html>";
            Response.ContentType = "text/html; charset=utf-8";
            await Response.WriteAsync(htmlStr);
        }

        [HttpPost]
        //public string Index(string name, int age)
        public string Index(User user, string[] skills)
        {
            //string name = Request.Form["name"];
            //string age = Request.Form["age"];

            string str = $"Name {user.Name}, Age {user.Age}\n";

            foreach (var s in skills)
                str += s + "\n";

            return str;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}