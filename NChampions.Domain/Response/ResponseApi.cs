namespace NChampions.Domain.Response
{
    public class ResponseApi
    {
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public ResponseApi(bool success, string message, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
