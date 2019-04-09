namespace DeliveryService.API.Dto
{
    public class ResultResponse<T>
    {
        public ResultResponse(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }

        public ResultResponse() { }

        public T Data;

        public bool Success;

        public string Message;
    }
}
