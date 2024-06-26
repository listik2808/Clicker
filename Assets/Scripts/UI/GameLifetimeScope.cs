using Scripts.Ui.ButtonUI;
using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Screpts.Ui
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private Presenter _presenter;
        [SerializeField] private ClickPanel _clickPanel;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_presenter);
            builder.RegisterComponent(_clickPanel);
        }
    }
}