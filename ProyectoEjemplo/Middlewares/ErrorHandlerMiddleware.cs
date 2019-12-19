using Microsoft.AspNetCore.Http;
using ProyectoEjemplo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProyectoEjemplo.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandlerExceptionAsync(context, e);
            }
        }

        private static Task HandlerExceptionAsync(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";

            HttpStatusCode code;
            string message;

            if (e is BadRequestException) code = HttpStatusCode.BadRequest;
            else if (e is UnauthorizedException) code = HttpStatusCode.Unauthorized;
            else if (e is NotAllowedException) code = HttpStatusCode.MethodNotAllowed;
            else if (e is UnprocesableEntity) code = HttpStatusCode.UnprocessableEntity;
            else if (e is NotFoundException) code = HttpStatusCode.NotFound;
            else code = HttpStatusCode.BadRequest;

            return ExceptionResponse(context, code, e.Message);
        }

        private static Task ExceptionResponse(HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.StatusCode = (int) code;

            return context.Response.WriteAsync(new ResponseError()
            {
                Code = context.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
