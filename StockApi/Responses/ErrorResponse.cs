namespace StockApi.Responses
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public List<string>? Errors { get; set; }

        public ErrorResponse(string message, int statusCode, List<string>? errors = null)
        {
            Message = message;
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
