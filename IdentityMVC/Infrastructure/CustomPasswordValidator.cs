﻿using IdentityMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityMVC.Infrastructure;

public class CustomPasswordValidator : IPasswordValidator<AppUser>
{
    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager,
        AppUser user, string password)
    {
        List<IdentityError> errors = new List<IdentityError>();
        if (password.ToLower().Contains(user.UserName.ToLower()))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordContainsUserName",
                Description = "Password cannot contain username"
            });
        }
        if (password.Contains("12345"))
        {
            errors.Add(new IdentityError
            {
                Code = "PasswordContainsSequence",
                Description = "Password cannot contain numeric sequence"
            });
        }
        return Task.FromResult(errors.Count == 0 ?
            IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
    }
}
