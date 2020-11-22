using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustMVP.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustMVP.Web.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected OkObjectResult Success() => Ok(new ResponseData<object>());
        protected OkObjectResult Success<T>(T data) => Ok(new ResponseData<T>(data));
        protected OkObjectResult Failure(ErrorTypeEnum errorType) => Ok(new ResponseData<object>(errorType));
        protected OkObjectResult Failure(ErrorTypeEnum errorType, object error) => Ok(new ResponseData<object>(errorType, error));
    }
}
