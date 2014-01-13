using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Autofac;

namespace HammerCreekBrewing.Framework.Mvc
{

    public class HttpControllerActivator : IHttpControllerActivator{

        private readonly IContainer _container;
        
        public HttpControllerActivator(IContainer container) {

            _container = container;
        }
                
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType) {

            var scope = _container.BeginLifetimeScope();
            var controller = (IHttpController)scope.Resolve(controllerType);
            request.RegisterForDispose(scope);
            return controller;            
        }

    }
}