using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace xCredidentials.Domain.Wrappers;



public class ApiResponse<T>
{
    public string Message { get; set; }
    public T Data { get; set; }
    public  ApiResponse(T data , string message)
    {

        Message = message;
            Data = data;

    }
    public  ApiResponse(string message)
    {

        Message = message;

 
    }

}
