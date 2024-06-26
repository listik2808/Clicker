using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Ui.ButtonUI
{
    public class ClickPanel : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public event Action OnClickPanel;

        private void OnEnable()
        {
            _button.onClick.AddListener(SendMessageAboutClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(SendMessageAboutClick);
        }

        private void SendMessageAboutClick()
        {
            OnClickPanel?.Invoke();
        }
    }
}