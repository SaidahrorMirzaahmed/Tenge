﻿namespace Tenge.WebApi.Models.Accounts;

public class ResetPasswordModel
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}
