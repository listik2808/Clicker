using Screpts.UI;
using Scripts.UI.ButtonUI;
using System;
using VContainer.Unity;

namespace Screpts
{
    public class Presenter : IStartable
    {
        private int _powerClic = 1;
        private ClickPanel _clickPanel;
        private CustomPool _customPool;
        private ProgresBar _progresBar;
        private CounterClick _counterClick;

        public Presenter(ClickPanel clickPanel,CustomPool customPool,ProgresBar progresBar,CounterClick counterClick)
        {
            _clickPanel = clickPanel;
            _customPool = customPool;
            _progresBar = progresBar;
            _counterClick = counterClick;
        }

        private void OnDisable()
        {
            _clickPanel.OnClickPanel -= StartClic;
        }

        public void Start()
        {
            _clickPanel.OnClickPanel += StartClic;
            _customPool.Spawn(_powerClic);
        }

        private void StartClic()
        {
            bool resulr = _progresBar.TryCountClick(_powerClic);
            if (resulr)
            {
                _customPool.Activate(_powerClic);
                _counterClick.AddClick(_powerClic);
            }
        }
    }
}