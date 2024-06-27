using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Screpts.UI
{
    public class UpgradePowerClick : MonoBehaviour
    {
        [SerializeField] private Button _buttonUpPowerClick;
        [SerializeField] private TMP_Text _priceUpgrade;
        [SerializeField] private TMP_Text _currentPowerClick;
        [SerializeField] private TMP_Text _nextPowerClick;
        CounterClick _counterClick;
        private int _currentPower = 1;
        private int _price = 10;

        public int CurrentPower => _currentPower;

        public event Action OnClickButtonUpPuwer;

        private void OnEnable()
        {
            _buttonUpPowerClick.onClick.AddListener(TryPayUpdgade);
            InteracteibleButtonUpgrade();
            Show();
        }

        private void OnDisable()
        {
            _buttonUpPowerClick.onClick.RemoveListener(TryPayUpdgade);
        }


        public void Construct(CounterClick counterClick)
        {
            _counterClick = counterClick;
        }

        public void TryPayUpdgade()
        {
            if (_counterClick.Counter >= _price)
                UpPowerClick();
        }

        private void UpPowerClick()
        {
            _price *= 2;
            _currentPower++;
            OnClickButtonUpPuwer?.Invoke();
            Show();
        }

        private void Show()
        {
            _currentPowerClick.text = "Current power "+ _currentPower.ToString();
            _nextPowerClick.text = "Next power " + (_currentPower + 1).ToString();
            _priceUpgrade.text = "price " + _price.ToString();
        }

        private void InteracteibleButtonUpgrade()
        {
            if (_counterClick.Counter >= _price)
                _buttonUpPowerClick.interactable = true;
            else
                _buttonUpPowerClick.interactable = false;
        }
    }
}