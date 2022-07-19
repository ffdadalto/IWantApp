﻿using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IWantApp.Endpoints.Employees;

public class EmployeePost
{
    public static string Template => "/employee";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static IResult Action(EmployeeRequest employeeRequest, UserManager<IdentityUser> userManager)
    {
        var user = new IdentityUser { UserName = employeeRequest.email, Email = employeeRequest.email };

        var result = userManager.CreateAsync(user, employeeRequest.password).Result;

        if (!result.Succeeded)
            return Results.BadRequest(result.Errors.First());

        var claimResult = userManager.AddClaimAsync(user, new Claim("EmployeeCode", employeeRequest.employeeCode)).Result;

        if (!claimResult.Succeeded)
            return Results.BadRequest(result.Errors.First());

        claimResult = userManager.AddClaimAsync(user, new Claim("Name", employeeRequest.name)).Result;

        if (!claimResult.Succeeded)
            return Results.BadRequest(result.Errors.First());


        return Results.Created($"/employee/{user.Id}", user.Id);
    }
}
