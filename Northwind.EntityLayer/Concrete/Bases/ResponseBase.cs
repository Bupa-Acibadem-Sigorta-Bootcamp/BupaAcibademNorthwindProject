using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.EntityLayer.Abstract.IBases;

namespace Northwind.EntityLayer.Concrete.Bases
{
    public class ResponseBase : IResponseBase
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
    }

    public class ResponseBase<T> : IResponseBase<T>
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}
