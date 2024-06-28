using Screpts.UI.PopUpScreen;
using Scripts.UI.ButtonUI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Screpts.UI.Windows
{
    public class CanvasShop : ScreenWindows
    {
        [SerializeField] private List<ButtonPupUp> _buttonProduct;
        [SerializeField] private List<Product> _products;
        private Product _currentProduct;

        private void OnEnable()
        {
            foreach (ButtonPupUp button in _buttonProduct)
            {
                button.OnClickproduct += OpenPopUpProduct;
            }
        }

        private void OnDisable()
        {
            foreach (ButtonPupUp button in _buttonProduct)
            {
                button.OnClickproduct -= OpenPopUpProduct;
            }
            _currentProduct.Diactivate();
            _currentProduct.gameObject.SetActive(false);
        }

        private void OpenPopUpProduct(int index)
        {
            foreach (Product item in _products)
            {
                if(item.Index == index)
                {
                    _currentProduct = item;
                    break;
                }
            }
            _currentProduct.gameObject.SetActive(true);
        }
    }
}