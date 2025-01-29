using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Application
{
    public abstract class AppService
    {
        public AppServiceResponse Ok()
        {
            return new AppServiceResponse
            {
                Result = new object(),
                StatusCode = StatusCodes.Status200OK,
                Messages = new List<string>()
            };
        }

        public AppServiceResponse Ok(object obj = null)
        {
            return new AppServiceResponse
            {
                Result = obj,
                StatusCode = StatusCodes.Status200OK,
                Messages = new List<string>()
            };
        }

        public AppServiceResponse Fail(int status, params string[] messages)
        {
            return new AppServiceResponse
            {
                Result = null,
                StatusCode = status,
                Messages = messages
            };
        }
    }

    public sealed class AppServiceResponse
    {
        public object Result { get; set; }
        public int StatusCode { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
