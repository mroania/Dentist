﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Dentist.Domain.DomainExceptions;

namespace Dentist.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                //var exp = exception.GetBaseException();
                //exp.GetType();
                await HandleErrorAsync(context, exception);
            }
        }

        private Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var exceptionResult = GetException(exception);
            var response = new { message = exceptionResult.Item1 };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exceptionResult.Item2;

            return context.Response.WriteAsync(payload);
        }

        private (string, int) GetException(Exception exception)
        {
            var key = _exceptionDictionary.Keys.FirstOrDefault(x => x(exception));
            if (key == null)
            {
                //Todo: logging
                return ("Internal Server Error", 500);
            }
            //Todo: logging
            return _exceptionDictionary[key](exception);
        }

        private Dictionary<Func<Exception, bool>, Func<Exception, (string, int)>> _exceptionDictionary =
            new Dictionary<Func<Exception, bool>, Func<Exception, (string, int)>>
            {
                [exception => exception.GetBaseException() is InvalidBirthDateException]
                    = exception => (exception.GetBaseException().Message, 400),

                [exception => exception.GetBaseException() is InvalidPhoneException]
                    = exception => (exception.GetBaseException().Message, 400)
            };

    }
}
