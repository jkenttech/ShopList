using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers;

public class RegistrationController(ShopListContext context) : Controller
{
    private readonly ShopListContext _context = context;

    [HttpPost]
    [Route("/register")]
    public async Task<JsonResult> PostRegisterLogin()
    {
        Response.StatusCode = 200;
        var jsonData = new {
            Method = "[GET]",
            Function = "RegisterController.PostRegisterLogin()"
        };
	    return Json(jsonData);
    }
}