using Scripts.Ui.ButtonUI;
using UnityEngine;
using UnityEngine.UI;

namespace Screpts.Ui
{
    public class ColorIcon : MonoBehaviour
    {
        [SerializeField] private PressingButton _pressingButton;
        [SerializeField] private Image _image;

        private void OnEnable()
        {
            _pressingButton.OnChangetColor += SetColorActivate;
        }

        private void OnDisable()
        {
            _pressingButton.OnChangetColor -= SetColorActivate;
        }

        private void SetColorActivate(bool result)
        {
            if(result)
                _image.color = new Color32(66, 170, 255, 100);
            else
                _image.color = Color.white;
        }
    }
}