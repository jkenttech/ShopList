using API.Models;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RegistrationController(ShopListContext context) : Controller
{
    private readonly string _controller = "RegistrationController";
    private readonly ShopListContext _context = context;

    [HttpPost]
    [Route("/register")]
    public JsonResult PostRegisterLogin(RegisterDTO postData)
    {
        List<string> error = [];
        int responseCode = 0;

        if(ModelState.IsValid)
        {
            responseCode = 200;

            if(postData.Password != postData.PasswordConfirm)
            {
                responseCode = 400;
                error.Add("Password and PasswordConfirm do not match.");
            }
        }

        if(postData.Password == null)
        {
            responseCode = 400;
            error.Add("Password is null.");
        }
        
        if(postData.PasswordConfirm == null)
        {
            responseCode = 400;
            error.Add("PasswordConfirm is null.");
        }

        Response.StatusCode = (responseCode == 0) ? Response.StatusCode = 418 : responseCode;

        var jsonData = new {
            Request.Method,
            Function = "RegistrationController.PostRegisterLogin(Login)",
            Error = error
        };

        return Json(jsonData);
    }
}