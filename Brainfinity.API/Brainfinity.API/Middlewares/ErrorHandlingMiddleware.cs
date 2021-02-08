using Brainfinity.Service.ErrorHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;

namespace Brainfinity.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;
        private ErrorModel errorModel;
        private readonly string validationExMessage = "Validation exception was thrown.";
        private readonly string notFoundExMessage = "NotFound exception was thrown.";
        private readonly string unauthorizedExMessage = "Unauthorized exception was thrown.";

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            string result = "";

            switch (ex)
            {
                case ValidationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(new { error = ex.Message });
                    this.errorModel = new ErrorModel(validationExMessage);
                    break;

                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    this.errorModel = new ErrorModel(notFoundExMessage);
                    break;

                case UnauthorizedException:
                    code = HttpStatusCode.Unauthorized;
                    this.errorModel = new ErrorModel(unauthorizedExMessage);
                    break;

                case TransactionAbortedException:
                    code = HttpStatusCode.BadRequest;
                    this.errorModel = new ErrorModel(ex.Message);
                    break;
            }
            logger.LogError(ex, errorModel.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}