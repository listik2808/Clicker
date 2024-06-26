using Screpts.Ui;
using Scripts.Ui.ButtonUI;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Ui.Windows
{
    public class ScreenActivationHandler : MonoBehaviour
    {
        [SerializeField] private List<PressingButton> _pressingButtons = new List<PressingButton>();
        [SerializeField] private List<ScreenWindows> _screns = new List<ScreenWindows>();

        private void OnEnable()
        {
            foreach (var item in _pressingButtons)
            {
                item.OnClickButtonScreen += ActivateScreen;
            }
        }

        private void OnDisable() 
        {
            foreach (var item in _pressingButtons)
            {
                item.OnClickButtonScreen -= ActivateScreen;
            }
        }

        private void Awake()
        {
            ActivateDefaltScreen(1);
            ActivateColorBattonDefalte(1);
        }

        private void ActivateColorBattonDefalte(int index)
        {
            foreach(var item in _pressingButtons)
            {
                if(item.ButtonIndex == index)
                {
                    item.Button.onClick.Invoke();
                }
            }
        }

        private void ActivateDefaltScreen(int index)
        {
            foreach (ScreenWindows item in _screns)
            {
                if (item.IndexScreen == index)
                {
                    item.gameObject.SetActive(true);
                }
            }
        }

        private void ActivateScreen(PressingButton pressingButton)
        {
            ChangingScreen(pressingButton);
        }

        private void ChangingScreen(PressingButton pressingButton)
        {
            foreach (var item in _screns)
            {
                if (item.IndexScreen == pressingButton.ButtonIndex)
                {
                    item.gameObject.SetActive(true);
                }
                else
                {
                    DefaltColorButton(pressingButton);
                    item.gameObject.SetActive(false);//возможно следует тут сделать евет о том что бы сам экран внутри себя вызвал метод о пошаговом отключение окон
                }
            }
        }

        private void DefaltColorButton(PressingButton pressingButton)
        {
            foreach (PressingButton button in _pressingButtons)
            {
                if (button.ButtonIndex != pressingButton.ButtonIndex)
                {
                    button.DefaultColorIcon();
                }
            }
        }
    }
}