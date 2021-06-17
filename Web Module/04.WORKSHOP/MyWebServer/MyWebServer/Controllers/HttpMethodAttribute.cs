namespace MyWebServer.Controllers
{
    using System;
    using MyWebServer.Http;

    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {
        protected HttpMethodAttribute(HttpMethod httpMethod)
            => this.HttpMehod = httpMethod;

        public HttpMethod HttpMehod { get; }
    }
}
