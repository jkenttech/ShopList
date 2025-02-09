using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class RootController : Controller
{
    [HttpGet]
    [Route("/")]
    [Route("/Index")]
    public JsonResult Index()
    {
        Response.StatusCode = 200;
        var jsonData = new {
            Request.Method,
            Function = "RootController.Index()"
        };
	    return Json(jsonData);
    }

    [HttpGet]
    [Route("/about")]
    public JsonResult About()
    {
        Response.StatusCode = 200;
        var jsonData = new {
            Request.Method,
            Function = "RootController.About()"
        };
	    return Json(jsonData);
    }

    [HttpGet]
    [Route("/privacy")]
    public JsonResult Privacy()
    {
        Response.StatusCode = 200;
        var jsonData = new {
            Request.Method,
            Function = "RootController.Privacy()"
        };
	    return Json(jsonData);
    }

    [HttpGet]
    [Route("/contact")]
    public JsonResult Contact()
    {
        Response.StatusCode = 200;
        var jsonData = new {
            Request.Method,
            Function = "RootController.Contact()"
        };
	    return Json(jsonData);
    }

    [HttpGet]
    [Route("/404")]
    public JsonResult FourOFour()
    {
        Response.StatusCode = 404;
        var jsonData = new {
            Request.Method,
            Function = "RootController.FourOFour()"
        };
	    return Json(jsonData);
    }
}