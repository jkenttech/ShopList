using API.Models;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers;

public class RegistrationController(ShopListContext context) : Controller
{
    private readonly string _controller = "RegistrationController";
    private readonly ShopListContext _context = context;

    [HttpPost]
    [Route("/register")]
    public async Task<JsonResult> PostRegisterLogin(RegisterDTO postData)
    {
        List<string> error = [];
        int responseCode = 0;

        if(ModelState.IsValid)
        {
            if(postData.Password != postData.PasswordConfirm)
            {
                responseCode = 400;
                error.Add("Password and PasswordConfirm do not match.");
            }

            if(error.Count == 0)
            {
                responseCode = 200;

                Login newUser = new(){
                    Email = postData.Email,
                    PasswordHash = postData.Password
                };

                _context.Logins.Add(newUser);
                await _context.SaveChangesAsync();
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