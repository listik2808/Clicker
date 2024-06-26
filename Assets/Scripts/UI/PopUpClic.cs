using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Screpts.Ui
{
    public class PopUpClic : Model
    {
        [SerializeField] private TMP_Text _value;
        [SerializeField] private RectTransform _transform;
        private Sequence _sequence;

        private void OnEnable()
        {
            _transform.anchoredPosition = Vector3.zero;
            _value.DOFade(1,0.1f);
            _sequence = DOTween.Sequence();
            _sequence.Append(_transform.DOAnchorPos(new Vector2(0, 470), 1.2f)).
                Insert(0.2f, _value.DOFade(0, 1.5f)).
                OnComplete(EndAnimation);
            
        }

        private void OnDisable()
        {
            _sequence.Kill(true);
        }

        private void EndAnimation()
        {
            gameObject.SetActive(false);
        }
    }
}