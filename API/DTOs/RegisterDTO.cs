using API.Abstracts;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticAssets;
using Npgsql.Replication;
using System.ComponentModel.DataAnnotations;
namespace API.DTOs;

public class RegisterDTO : User
{
    private readonly PasswordHasher<UserAbstract> _hasher = new();

    [StringLength(96, MinimumLength = 5, ErrorMessage = "Passwords must be between {1} and {2} characters")]
    required public string Password { get; set; }

    [Compare(nameof(Password), ErrorMessage = "Password and password confirmation do not match.")]
    required public string PasswordConfirm { get; set; }

    public string HashPassword(string password)
    {
        return _hasher.HashPassword(this, password);
    }
}