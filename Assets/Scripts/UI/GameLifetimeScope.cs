using Screpts.Infrastructure;
using Scripts.Ui.ButtonUI;
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Screpts.Ui
{
    public class GameLifetimeScope : LifetimeScope
    { 
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<CustomPool>();
            builder.RegisterComponentInHierarchy<ClickPanel>();
            builder.Register<Presenter>(Lifetime.Singleton);
            builder.RegisterEntryPoint<Presenter>();
        }
    }
}