namespace App.Middleware
{
    public class CheckLoginMiddleware
    {
        private readonly RequestDelegate _next;

        public CheckLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var id = context.Session.GetInt32("_role");
            if (context.Request.Path.StartsWithSegments("/Admin") && id == null)
            {
                context.Response.Redirect("/Home/Login");
            }
            else if (context.Request.Path.StartsWithSegments("/Admin") && id > 2)
            {
                context.Response.Redirect("/Home/Index");
            }
            await _next(context);
        }
    }
}
