namespace Workshop01.BackEnd.Model.Response.Common;

    public class BaseResponses<T>
    {
        public decimal Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = "unexpected error";
        public List<string> Errors { get; set; } = new List<string>();
        public T? ResponseObject { get; set; }
    }

