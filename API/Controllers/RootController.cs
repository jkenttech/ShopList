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
	    return Json("RootController.Index()");
    }

    [HttpGet]
    [Route("/about")]
    public JsonResult About()
    {
        Response.StatusCode = 200;
	    return Json("RootController.About()");
    }

    [HttpGet]
    [Route("/privacy")]
    public JsonResult Privacy()
    {
        Response.StatusCode = 200;
	    return Json("RootController.Privacy()");
    }

    [HttpGet]
    [Route("/contact")]
    public JsonResult Contact()
    {
        Response.StatusCode = 200;
	    return Json("RootController.Contact()");
    }

    [HttpGet]
    [Route("/404")]
    public JsonResult FourOFour()
    {
        Response.StatusCode = 404;
	    return Json("RootController.Contact()");
    }
}
