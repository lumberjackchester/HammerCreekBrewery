
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;

namespace HammerCreekBrewing.Factories
{
    public class MvcControllerFactory : DefaultControllerFactory {

        private readonly IContainer _container;
        private readonly Dictionary<IController, Autofac.ILifetimeScope> _scopes;
        private readonly object _syncRoot;


        public MvcControllerFactory(IContainer container)
        {

            if (container == null) {
                throw new ArgumentNullException("container");
            }

            _container = container;
            _scopes = new Dictionary<IController, ILifetimeScope>();
            _syncRoot = new object();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            var scope = _container.BeginLifetimeScope();
            var controller = (IController)scope.Resolve(controllerType);

            lock (_syncRoot) {
                _scopes.Add(controller, scope);
            }

            return controller;
        }

        public override void ReleaseController(IController controller) {
            lock (_syncRoot) {
                var scope = _scopes[controller];
                _scopes.Remove(controller);

                scope.Dispose();
            }
            base.ReleaseController(controller);
        }

    }         
}
 