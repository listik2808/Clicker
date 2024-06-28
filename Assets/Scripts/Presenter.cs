using Screpts.UI;
using Scripts.UI.ButtonUI;
using UnityEngine;
using VContainer.Unity;

namespace Screpts
{
    public class Presenter : IStartable
    {
        private ClickPanel _clickPanel;
        private CustomPool _customPool;
        private ProgresBar _progresBar;
        private CounterClick _counterClick;
        private UpgradePowerClick _upgradePowerClick;

        public Presenter(ClickPanel clickPanel,CustomPool customPool,ProgresBar progresBar,CounterClick counterClick,UpgradePowerClick upgradePowerClick)
        {
            _clickPanel = clickPanel;
            _customPool = customPool;
            _progresBar = progresBar;
            _counterClick = counterClick;
            _upgradePowerClick = upgradePowerClick;
        }

        private void OnDisable()
        {
            _clickPanel.OnClickPanel -= StartClic;
            _upgradePowerClick.OnClickButtonUpPuwer -= SetPowerClick;
        }

        public void Start()
        {
            _upgradePowerClick.Construct(_counterClick);
            _clickPanel.OnClickPanel += StartClic;
            _upgradePowerClick.OnClickButtonUpPuwer += SetPowerClick;
            _customPool.Spawn(_upgradePowerClick.CurrentPower);
        }

        public void SetPowerClick()
        {
            _customPool.UpdateClickPower(_upgradePowerClick.CurrentPower);
        }

        private void StartClic()
        {
            Debug.Log(_upgradePowerClick.CurrentPower + "(9)");
            bool resulr = _progresBar.TryCountClick(_upgradePowerClick.CurrentPower);
            if (resulr)
            {
                _customPool.Activate(_upgradePowerClick.CurrentPower);
                _counterClick.AddClick(_upgradePowerClick.CurrentPower);
            }
        }
    }
}