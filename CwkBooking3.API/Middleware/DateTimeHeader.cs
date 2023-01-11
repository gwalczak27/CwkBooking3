﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CwkBooking3.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DateTimeHeader
    {
        private readonly RequestDelegate _next;

        public DateTimeHeader(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // executed on the request
            httpContext.Request.Headers.Add("my-custom-middleware", DateTime.Now.ToString());
            await Task.FromResult(_next(httpContext));
            
            // executed on the response
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DateTimeHeaderExtensions
    {
        public static IApplicationBuilder UseDateTimeHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DateTimeHeader>();
        }
    }
}
