﻿using Base.Infrastructure.CrossCutting.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Base.Application.Api.Attributes
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var codigo = Marshal.GetExceptionCode().ToString();
            var messagem = context.Exception.Message;
            var rastreamento = context.Exception.StackTrace;
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new JsonResult(new ResultadoBase(codigo, messagem, rastreamento));

            base.OnException(context);
        }
    }
}
