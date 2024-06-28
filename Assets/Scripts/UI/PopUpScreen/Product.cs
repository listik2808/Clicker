using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Screpts.UI.PopUpScreen
{
    public class Product : MonoBehaviour
    {
        [SerializeField] private Button _exit;
        [SerializeField] private Button _payProduct;
        [SerializeField] private TMP_Text _additionalPower;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private int _pricePay;
        [SerializeField] private int _powerClick;
        [SerializeField] private int _index;
        [SerializeField] private TMP_Text _counter;
        private CounterClick _counterClick;
        private UpgradePowerClick _upgradePowerClick;
        private bool _isPay = false;
        private bool _isOpen = false;

        public int Index => _index;

        private void OnEnable()
        {
            _isOpen = true;
            _exit.onClick.AddListener(Exit);
            _payProduct.onClick.AddListener(TryPay);
        }

        private void OnDisable()
        {
            _exit.onClick.RemoveListener(Exit);
            _payProduct.onClick.RemoveListener(TryPay);
        }

        private void Start()
        {
            _price.text = "Price \n" + _pricePay;
            _additionalPower.text = "Power + " + _powerClick;
            _counter.text = _counterClick.Counter.ToString();
            int result = SaveProgress.LoadIntProduct(_index);
            if(result > 0)
            {
                _isPay = true;
                _payProduct.interactable = false;
            }
            else if(result == 0)
            {
                _isPay = false;
                _payProduct.interactable = true;
            }
        }

        [Inject]
        public void InjectDependencies(CounterClick counterClick,UpgradePowerClick upgradePowerClick)
        {
            _counterClick = counterClick;
            _upgradePowerClick = upgradePowerClick;
        }

        public void Diactivate()
        {
            _isPay = false;
        }

        private void Exit()
        {
            gameObject.SetActive(false);
        }

        private void TryPay()
        {
            if(_counterClick.Counter >= _pricePay)
            {
                _isPay = true;
                _payProduct.interactable = false;
                _counterClick.Pay(_pricePay);
                SaveProgress.SaveProgressProduct(_index, 1);
                _payProduct.interactable = false;
                _upgradePowerClick.UpPower(_powerClick);
                _counter.text = _counterClick.Counter.ToString();
                gameObject.SetActive(false);
            }
        }
    }
}