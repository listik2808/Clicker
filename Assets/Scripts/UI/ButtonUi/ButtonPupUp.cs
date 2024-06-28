using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.ButtonUI
{
    public class ButtonPupUp : MonoBehaviour
    {
        [SerializeField] private Button _product;
        [SerializeField] private int _index;

        public int ProductIndex => _index;

        public event Action<int> OnClickproduct;

        private void OnEnable()
        {
            _product.onClick.AddListener(OpenPopUpProduct);
        }

        private void OnDisable()
        {
            _product.onClick.RemoveListener(OpenPopUpProduct);
        }

        private void OpenPopUpProduct()
        {
            OnClickproduct?.Invoke(_index);
        }
    }
}