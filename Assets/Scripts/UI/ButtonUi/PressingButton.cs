using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI.ButtonUI
{
    public class PressingButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private int _buttonIndex;
        private bool _isclick = false;

        public Button Button => _button;
        public int ButtonIndex => _buttonIndex;

        public event Action<PressingButton> OnClickButtonScreen;
        public event Action<bool> OnChangetColor;

        private void OnEnable()
        {
            _button.onClick.AddListener(PlayClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PlayClick);
        }

        public void DefaultColorIcon()
        {
            if(_isclick)
            {
                _isclick = false;
                _button.enabled = true;
                OnChangetColor?.Invoke(_isclick);
            }
        }

        private void PlayClick()
        {
            _isclick = true;
            _button.enabled = false;
            OnClickButtonScreen?.Invoke(this);
            OnChangetColor?.Invoke(_isclick);
        }
    }
}