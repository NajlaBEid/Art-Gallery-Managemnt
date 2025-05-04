//namespace Art_Gallery_Management.LoggingMiddleware { 

//    using Microsoft.AspNetCore.Http;
//using Serilog;
//using System.IO;
//using System.Threading.Tasks;
//public class LoggingMiddleware
//{
//    private readonly RequestDelegate _next;
//    public LoggingMiddleware(RequestDelegate next)
//    {
//        _next = next;
//    }

//    public async Task Invoke(HttpContext context) {
//        context.Request.EnableBuffering();
//        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
//        context.Request.Body.Position = 0;

//        Log.Information("HTTP {Method} {Path} Request Body: {RequestBody}",
//            context.Request.Method,context.Request.Path, requestBody);  

//        await _next(context);

//    }
//}
//}
