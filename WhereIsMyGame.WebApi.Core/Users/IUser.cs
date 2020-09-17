using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WhereIsMyGame.WebApi.Core.Users
{
    public interface IUser
    {
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        string GetUserToken();
        bool IsAuthenticated();
        bool HasRole(string role);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();
    }

}