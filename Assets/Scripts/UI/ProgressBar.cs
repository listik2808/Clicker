using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screpts.UI
{
    public class ProgresBar : MonoBehaviour
    {
        public const string KayLevel = "Level";
        public const string KayCountClick = "CountClick";
        public const string KayMaxCount = "MaxCount";
        public const string KayRemainingClicks = "RemainingClicks";
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _levelText;
        [Range(1, 30)]
        [SerializeField] private int _maxValueClick = 10;
        [SerializeField] private TMP_Text _textCountClick;
        private int _countClick;
        private int _currentValueClick = 0;
        private int _level = 0;
        private int _clicks;

        private void Start()
        {
            _level = SaveProgress.LoadInt(KayLevel);
            _currentValueClick = SaveProgress.LoadInt(KayCountClick);
            _maxValueClick = SaveProgress.LoadInt(KayMaxCount);
            if(_maxValueClick == 0)
                _maxValueClick = 10;
            _countClick = SaveProgress.LoadInt(KayRemainingClicks);
            if (_countClick == 0)
            {
                SetCountClick();
            }
            RenderinBar();
            ShowLevel();
            ShowTextCountClick();
            
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
            if (_currentValueClick + count > _maxValueClick)
            {
                _clicks = _currentValueClick + count - _maxValueClick;
                _currentValueClick = _maxValueClick;
                _countClick = 0;
            }
            else
            {
                _currentValueClick += count;
                _countClick -= count;
            }
            
            if (PossibleRaiseLevel())
                UpLevel();
            RenderinBar();
            ShowTextCountClick();
            SaveProgress.SaveProgressInt(KayLevel, _level);
            SaveProgress.SaveProgressInt(KayMaxCount, _maxValueClick);
            SaveProgress.SaveProgressInt(KayRemainingClicks, _countClick);
            SaveProgress.SaveProgressInt(KayCountClick, _currentValueClick);
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
            if (_clicks > 0)
            {
                _currentValueClick = _clicks;
                _countClick -= _clicks;
                _clicks = 0;
            }
            
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