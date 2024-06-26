using Screpts.Ui;
using Scripts.Ui.ButtonUI;
using UnityEngine;
using VContainer.Unity;

namespace Screpts
{
    public class Presenter : IStartable
    {
        private ClickPanel _clickPanel;
        private CustomPool _customPool;

        public Presenter(ClickPanel clickPanel,CustomPool customPool)
        {
            _clickPanel = clickPanel;
            _customPool = customPool;
        }

        private void OnDisable()
        {
            _clickPanel.OnClickPanel -= StartClic;
        }

        public void Start()
        {
            _clickPanel.OnClickPanel += StartClic;
            _customPool.Spawn();
        }

        private void StartClic()
        {
            _customPool.Activate();

        }
    }
}