using Scripts.UI.ButtonUI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Screpts.UI
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private CounterClick _counterClick;
        [SerializeField] private UpgradePowerClick _upgradePowerClick;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_counterClick);
            builder.RegisterComponent(_upgradePowerClick);

            builder.RegisterComponentInHierarchy<CustomPool>();
            builder.RegisterComponentInHierarchy<ClickPanel>();
            builder.RegisterComponentInHierarchy<ProgresBar>();

            builder.Register<Presenter>(Lifetime.Singleton);
            builder.RegisterEntryPoint<Presenter>();
        }
    }
}