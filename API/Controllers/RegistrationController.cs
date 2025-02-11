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

        if(!ModelState.IsValid)
        {
            responseCode = 400;

            if(postData.Password == null)
                { error.Add("Password is null."); }
            
            if(postData.PasswordConfirm == null)
                { error.Add("PasswordConfirm is null."); }
            
            if(postData.FirstName == null)
                { error.Add("FirstName is null."); }
        }

        if(postData.Password != postData.PasswordConfirm)
        {
            responseCode = 400;
            error.Add("Password and PasswordConfirm do not match.");
        }

        if(error.Count == 0)
        {
            responseCode = 200;

            Login newLogin = new()
            {
                Email = postData.Email,
                PasswordHash = postData.Password!
            };
            _context.Logins.Add(newLogin);

            User newUser = new()
            {
                Email = postData.Email,
                FirstName = postData.FirstName!,
                LastName = postData.LastName,
                ProfilePicture = postData.ProfilePicture,
                AccountType = "user"
            };
            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();
        }

        // If there is an unknown error and the response code hasn't been set
        // then return 418 I'M A TEAPOT
        Response.StatusCode = (responseCode == 0) ? Response.StatusCode = 418 : responseCode;

        var jsonData = new {
            Request.Method,
            Function = "RegistrationController.PostRegisterLogin(Login)",
            Error = error
        };

        return Json(jsonData);
    }
}