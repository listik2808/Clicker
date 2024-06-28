using Screpts.UI.PopUpScreen;
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
        [SerializeField] private Product _productBitcoin;
        [SerializeField] private Product _productGold;
        [SerializeField] private Product _productCrystal;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_counterClick);
            builder.RegisterComponent(_upgradePowerClick);
            builder.RegisterComponent(_productCrystal);

            builder.RegisterComponentInHierarchy<CustomPool>();
            builder.RegisterComponentInHierarchy<ClickPanel>();
            builder.RegisterComponentInHierarchy<ProgresBar>();
            builder.Register<Presenter>(Lifetime.Singleton);
            builder.RegisterEntryPoint<Presenter>();
        }
    }
}