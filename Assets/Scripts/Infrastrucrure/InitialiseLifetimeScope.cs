using VContainer;
using VContainer.Unity;

namespace Screpts.Infrastructure
{
    public class InitialiseLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<GameBootstrapper>();
            builder.Register<Game>(Lifetime.Scoped);
            builder.RegisterEntryPoint<Game>();
        }
    }
}