using System.Web.Mvc;

namespace WebSessions
{
    public class VizewAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute),true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            if (filterContext.HttpContext.Session[SessionKey.User] == null)
                filterContext.Result = new RedirectResult("/home/login");
            //base.OnAuthorization(filterContext);
        }
    }
}