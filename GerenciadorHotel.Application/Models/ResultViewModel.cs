namespace GerenciadorHotel.Application.Models;

public class ResultViewModel
{
    public ResultViewModel(bool success = true, string message = "")
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
}

public class ResultViewModel<T> : ResultViewModel
{
    public ResultViewModel(T? data, bool success = true, string message = "") : base(success, message) 
    {
        Data = data;
    }
    
    public T Data { get; private set; }
    
    public static ResultViewModel<T> Success(T data)
        => new(data);
    
    public static ResultViewModel<T> Error(string message)
        => new(default, false, message);
}

