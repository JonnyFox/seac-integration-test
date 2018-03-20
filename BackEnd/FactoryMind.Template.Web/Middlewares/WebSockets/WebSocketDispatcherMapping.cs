using System;
using System.Collections.Generic;

namespace FactoryMind.Template.Web.Middlewares.WebSockets
{
    public sealed class WebSocketDispatcherMapping
    {
        private readonly IDictionary<string, Type> _mappedHandlers = new Dictionary<string, Type>();

        internal WebSocketDispatcherMapping()
        {
            // It is my business to instantiate this class    
        }

        public void AddHandler(string path, Type handlerType)
        {
            if (_mappedHandlers.ContainsKey(path))
            {
                throw new NotSupportedException($"Web socket path {path} is already mapped to {handlerType.FullName}");
            }

            _mappedHandlers.Add(path, handlerType);
        }

        public Type GetHandler(string path) => _mappedHandlers.ContainsKey(path)
            ? _mappedHandlers[path]
            : null;
    }
}