using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screpts.UI
{
    public class ProgresBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _levelText;
        [Range(1, 30)]
        [SerializeField] private int _maxValueClick = 10;
        [SerializeField] private TMP_Text _textCountClick;
        private int _countClick;
        private int _currentValueClick = 0;
        private int _level = 0;

        private void Start()
        {
            RenderinBar();
            ShowLevel();
            ShowTextCountClick();
            SetCountClick();
        }

        public bool TryCountClick(int value)
        {
            if (value > 0)
            {
                TakeClick(value);
                return true;
            }
            else 
            {
                return false; 
            }
        }

        private void RenderinBar()
        {
            _slider.value = (float)_currentValueClick / (float)_maxValueClick;
        }

        private void TakeClick(int count)
        {
            _currentValueClick += count;
            _countClick -= count;
            if (PossibleRaiseLevel())
                UpLevel();
            RenderinBar();
            ShowTextCountClick();
        }

        private bool PossibleRaiseLevel()
        {
            if (_currentValueClick == _maxValueClick)
            {
                _currentValueClick = 0;
                _countClick = 0;
                return true;
            }

            return false;
        }

        private void ShowTextCountClick()
        {
            _textCountClick.text = _countClick.ToString() + "Count Click";
        }

        private void UpLevel()
        {
            _level++;
            _maxValueClick *= 2;
            SetCountClick();
            ShowLevel();
        }

        private void ShowLevel()
        {
            _levelText.text = "Level " + _level.ToString();
        }

        private void SetCountClick()
        {
            _countClick = _maxValueClick;
        }
    }
}