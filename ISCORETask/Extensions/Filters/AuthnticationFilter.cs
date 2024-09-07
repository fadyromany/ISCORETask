using ISCORETask.API.Controllers;
using ISCORETask.DTOs.Common;
using ISCORETask.Services.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using SendGrid.Helpers.Errors.Model;
using System.Security.Claims;

namespace ISCORETask.API.Extensions.Filters
{
    public class AuthnticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.Controller is ApiBaseController baseController)
            {
                try
                {
                    var svc = context.HttpContext.RequestServices;
                    var deleteduser = svc.GetService(typeof(IAccountService)) as IAccountService;

                    var identity = context.HttpContext.User.Identity as ClaimsIdentity;
                    baseController.UserId = identity.FindFirst("Id").Value;
                    //if (deleteduser.isDeleted(baseController.MobileToken))
                    //{
                    //    context.HttpContext.Response.StatusCode = 401;
                    //    throw new UnauthorizedAccessException("You Are Not Authorized !");
                    //}
                    //else
                    //{
                        baseController.UserId = identity.FindFirst("userId").Value;

                    //}
                }
                catch
                {
                    context.HttpContext.Response.StatusCode = 401;
                    throw new UnauthorizedAccessException("You Are Not Authorized !");
                }
            }
        }
    }
    public class MyException : UnauthorizedException
    {
        public ErrorResponse Error { get; set; }
        public MyException(ErrorResponse error)
        {
            Error = error;
        }

    }
}
