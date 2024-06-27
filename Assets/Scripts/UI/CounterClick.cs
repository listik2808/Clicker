using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Screpts.UI
{
    public class CounterClick : MonoBehaviour
    {
        [SerializeField] private TMP_Text _counterText;
        private List<string> _chars = new List<string>() { "", "K", "M", "B", "T", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n" };
        private float _counter;
        private int _number = 0;
        private string _valueCounter;

        public float Counter => _counter;

        public void AddClick(int value)
        {
            _counter += value;
            ShortNumber(_counter);
            Show();
        }

        private void Show()
        {
            _counterText.text = _valueCounter + " Clicks";
        }

        private string ShortNumber(float value)
        {
            _number = 0;
            while (value >= 1000)
            {
                _number++;
                value /= 1000;
            }
            _valueCounter = value.ToString();
            int _index = _valueCounter.IndexOf(',');
            
            if (_index > -1)
            {
                float res = (float)Math.Round(value, 2);
                _valueCounter = res.ToString();
            }
            _valueCounter = _valueCounter.Replace(",", ".");
            return _valueCounter;
        }
    }
}