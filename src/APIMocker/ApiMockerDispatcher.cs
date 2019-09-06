namespace APIMocker
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class ApiMockerDispatcher
    {
        private readonly Dictionary<string, string> _dataset;

        public ApiMockerDispatcher(Dictionary<string, string> dataset)
        {
            _dataset = dataset;
        }

        public ApiMockerResult Resolve(string url)
        {
            var urlparsed = url.Replace("/", "");
            string content = "";
            bool isfound = _dataset.TryGetValue(urlparsed, out content);
            return (isfound)?  ApiMockerResult.JsonOk(content): ApiMockerResult.JsonNotFound("");
        }

    }
}