using System;
using System.Net.Http;

namespace Refit
{
    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract HttpMethod Method { get; }

        protected string path;
        public virtual string Path {
            get { return path; }
            protected set { path = value; }
        }

        public HttpMethodAttribute(string path)
        {
            Path = path;
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class GetAttribute : HttpMethodAttribute
    {
        public GetAttribute(string path) : base(path) {}

        public override HttpMethod Method {
            get { return HttpMethod.Get; }
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class PostAttribute : HttpMethodAttribute
    {
        public PostAttribute(string path) : base(path) {}

        public override HttpMethod Method {
            get { return HttpMethod.Post; }
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class PutAttribute : HttpMethodAttribute
    {
        public PutAttribute(string path) : base(path) {}

        public override HttpMethod Method {
            get { return HttpMethod.Put; }
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class DeleteAttribute : HttpMethodAttribute
    {
        public DeleteAttribute(string path) : base(path) {}

        public override HttpMethod Method {
            get { return HttpMethod.Delete; }
        }
    }
        
    [AttributeUsage(AttributeTargets.Method)]
    public class HeadAttribute : HttpMethodAttribute
    {
        public HeadAttribute(string path) : base(path) {}

        public override HttpMethod Method {
            get { return HttpMethod.Head; }
        }
    }

    public enum BodySerializationMethod {
        Json, Xml,
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class BodyAttribute : Attribute
    {
        public BodySerializationMethod SerializationMethod { get; protected set; }

        public BodyAttribute(BodySerializationMethod serializationMethod = BodySerializationMethod.Json)
        {
            SerializationMethod = serializationMethod;
        }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    public class AliasAsAttribute : Attribute
    {
        public string Name { get; protected set; }
        public AliasAsAttribute(string name)
        {
            this.Name = name;
        }
    }
}