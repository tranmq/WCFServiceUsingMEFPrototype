using System;
using System.ComponentModel.Composition.Hosting;
using System.ServiceModel;

namespace WrgServiceHost
{
    public class ComposedServiceHost : ServiceHost
    {
        private readonly Type _serviceType;
        private readonly CompositionContainer _container;

        public ComposedServiceHost(Type serviceType, CompositionContainer container, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            _serviceType = serviceType;
            _container = container;
        }

        protected override void OnOpening()
        {
            if (Description.Behaviors.Find<ComposedServiceBehavior>() == null)
            {
                Description.Behaviors.Add(new ComposedServiceBehavior(_serviceType, _container));
            }

            base.OnOpening();
        }
    }
}