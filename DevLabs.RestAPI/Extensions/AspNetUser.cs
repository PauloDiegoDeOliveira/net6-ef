﻿using DevLabs.Domain.Core.Interfaces.Service;
using System.Security.Claims;

namespace DevLabs.RestAPI.Extensions
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public Guid GetUserId()
        {
            return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }

        public string GetUserEmail()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserEmail() : "";
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public string GetUserRole()
        {
            return IsAuthenticated() ? _accessor.HttpContext.User.GetUserRole() : "";
        }

        public IEnumerable<string> GetUserClaims()
        {
            return _accessor.HttpContext.User.GetUserClaims();
        }
    }

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }

        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst(ClaimTypes.Email);
            return claim?.Value;
        }

        public static string GetUserRole(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var role = principal.FindFirst(ClaimTypes.Role);
            return role?.Value;
        }

        public static IEnumerable<string> GetUserClaims(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claims = principal.Claims.Select(x => x.Type).Distinct();
            return claims;
        }
    }
}