namespace APIMocker
{
    public class ApiMockerResult
    {
        public int StatusCode { get; }
        public string ContentType { get; }
        public string Content { get; }

        private ApiMockerResult(int statuscode, string contenttype, string content)
        {
            StatusCode = statuscode;
            Content = content;
            ContentType = contenttype;
        }

        public static ApiMockerResult JsonOk(string content)
        {
            return new ApiMockerResult(200, "application/json", content);
        }

        public static ApiMockerResult JsonNotFound(string content)
        {
            return new ApiMockerResult(404, "application/json", content);
        }
    }
}