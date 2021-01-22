using PrasadCodeFirst.Web.Extensions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PrasadCodeFirst.Web.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var nullArgs = actionContext.ActionArguments.Where(kv => kv.Value == null).Select(kv => string.Format("The argument '{0}' cannot be null", kv.Key));
            if (nullArgs.Any())
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, string.Join("\n", nullArgs));
            }
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState.ToErrorString());
            }
        }
    }
}