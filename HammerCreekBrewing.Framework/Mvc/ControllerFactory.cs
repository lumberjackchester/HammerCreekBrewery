using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;


namespace HammerCreekBrewing.Framework.Mvc
{

    public class ControllerFactory : DefaultControllerFactory {

        private readonly IContainer _container;
        private readonly Dictionary<IController, ILifetimeScope> _scopes;
        private readonly object _syncRoot;


        public ControllerFactory(IContainer container)
        {

            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
            _scopes = new Dictionary<IController, ILifetimeScope>();
            _syncRoot = new object();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            var scope = _container.BeginLifetimeScope();
            //
            if (controllerType != null)
            {
                return (IController)_container.Resolve(controllerType);
            }
            else
            {
                return base.GetControllerInstance(controllerType);
            } var controller = (IController)scope.Resolve(controllerType);

            lock (_syncRoot)
            {
                _scopes.Add(controller, scope);
            }

            return controller;
        }

        public override void ReleaseController(IController controller)
        {
            lock (_syncRoot)
            {
                var scope = _scopes[controller];
                _scopes.Remove(controller);

                scope.Dispose();
            }
            base.ReleaseController(controller);
        }

    }         
}
