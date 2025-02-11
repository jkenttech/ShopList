using API.DTOs;
using API.Enums;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class RegistrationController(ShopListContext context) : Controller
{
    private readonly ShopListContext _context = context;
    private int responseCode;
    private readonly string _controllerName = "RegistrationController.";
    private string? functionName;

    [HttpPost]
    [Route("/register")]
    public async Task<JsonResult> PostRegisterUser(RegisterDTO postData)
    {
        responseCode = 0;
        functionName = $"{_controllerName}PostRegisterUser(RegisterDTO)";

        if(!ModelState.IsValid)
            { responseCode = 400; }

        if(responseCode == 0)
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
                AccountType = AccountType.User
            };
            _context.Users.Add(newUser);

            await _context.SaveChangesAsync();
        }

        // If there is an unknown error and the response code hasn't been set
        // then return 418 I'M A TEAPOT
        Response.StatusCode = (responseCode == 0) ? Response.StatusCode = 418 : responseCode;

        // Serialise the data into an anonymous JSON object and return
        var jsonData = new {
            Request.Method,
            Function = functionName,
            ModelState
        };

        return Json(jsonData);
    }
}