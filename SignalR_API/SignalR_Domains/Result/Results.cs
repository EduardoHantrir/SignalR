using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Domains.Result
{
    public class Results <T>
    {
        public bool Success { get; set; }
        public List<string> Message { get; set; }
        public T Data { get; set; }

        public Results(bool success, List<string> message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static Results<T> SucessResult(T data, List<string>? message = null)
        {
            return new Results<T>(true, message ?? [], data);
        }

        public static Results<T> FailureResult(List<string> message)
        {
            return new Results<T>(false, message, default!);
        }
    }
}
