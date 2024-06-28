using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Screpts.UI
{
    public class UpgradePowerClick : MonoBehaviour
    {
        public const string PowerClickKay = "powerClicKay";
        [SerializeField] private Button _buttonUpPowerClick;
        [SerializeField] private TMP_Text _priceUpgrade;
        [SerializeField] private TMP_Text _currentPowerClick;
        [SerializeField] private TMP_Text _nextPowerClick;
        [SerializeField] private TMP_Text _counterClickText;
        CounterClick _counterClick;
        private int _currentPower = 1;
        private int _price = 10;

        public int CurrentPower => _currentPower;

        public event Action OnClickButtonUpPuwer;

        private void OnEnable()
        {
            _buttonUpPowerClick.onClick.AddListener(TryPayUpdgade);
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

        private void Start()
        {
            _currentPower = SaveProgress.LoadInt(PowerClickKay);
            if (_currentPower == 0)
            {
                _currentPower = 1;
            }
        }

        public void TryPayUpdgade()
        {
            if (_counterClick.Counter >= _price)
            {
                _counterClick.Pay(_price);
                _counterClickText.text = _counterClick.Counter.ToString();
                UpPowerClick();
            }
        }

        public void UpPower(int power)
        {
            _currentPower += power;
            SaveProgress.SaveProgressInt(PowerClickKay, _currentPower);
            OnClickButtonUpPuwer?.Invoke();
        }

        private void UpPowerClick()
        {
            _price *= 2;
            _currentPower++;
            SaveProgress.SaveProgressInt(PowerClickKay, _currentPower);
            OnClickButtonUpPuwer?.Invoke();
            Show();
        }

        private void Show()
        {
            _currentPowerClick.text = "Current power "+ _currentPower.ToString();
            _nextPowerClick.text = "Next power " + (_currentPower + 1).ToString();
            _priceUpgrade.text = "price " + _price.ToString();
            _counterClickText.text = _counterClick.Counter.ToString() + "Count Click";
        }
    }
}