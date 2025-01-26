using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class RootController : Controller
{
    [HttpGet]
    public JsonResult Index()
    {
	return Json("RootController.Index()");
    }
}
