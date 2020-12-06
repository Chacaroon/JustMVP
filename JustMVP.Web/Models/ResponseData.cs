using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustMVP.Web.Models
{
    public class ResponseData<T>
    {
        public ResponseData()
        {
        }

        public ResponseData(T data)
        {
            Data = data;
        }

        public ResponseData(ErrorTypeEnum errorType)
        {
            IsError = true;
            Error = new ErrorResponseData()
            {
                ErrorType = errorType
            };
        }

        public ResponseData(ErrorTypeEnum errorType, object error) : this(errorType)
        {
            Error.Data = error;
        }

        public bool IsError { get; }

        public T Data { get; }

        public ErrorResponseData Error { get; }
    }

    public class ResponseData : ResponseData<object>
    {
        public ResponseData(ErrorTypeEnum errorType) : base(errorType)
        {
        }

        public ResponseData(ErrorTypeEnum errorType, object error) : base(errorType, error)
        {
        }
    }

    public class ErrorResponseData
    {
        public ErrorTypeEnum ErrorType { get; set; }

        public object Data { get; set; }
    }

    public enum ErrorTypeEnum
    {
        Unknown = 0,
        Custom = 1,
        NotAuthorized = 2,
        NotFound = 3
    }
}
