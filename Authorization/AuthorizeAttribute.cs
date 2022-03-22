using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Entities.Enums;

namespace SchoolOfDevs.Authorization
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<TypeUserEnum> _roles;

        public AuthorizeAttribute(params TypeUserEnum[] roles)
        {
            _roles = roles ?? Array.Empty<TypeUserEnum>();
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>();
            if (allowAnonymous != null)
                return;

            var user = (User)context.HttpContext.Items["Users"];

            if (user != null || (_roles.Any() && !_roles.Contains(user.TypeUser)))
            {
                context.Result = new JsonResult(new { message = "Usuário não autorizado" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
