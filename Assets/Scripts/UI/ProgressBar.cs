using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgresBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _levelText;
    [Range(1,30)]
    [SerializeField] private float _maxValue = 10;
    private float _currentValue = 0;
    private int _level = 0;

    public void RenderinBar()
    {
        _slider.value = _maxValue / _currentValue;
    }

    private void UpLevel()
    {
        _level++;
    }

    private void ShowLevel()
    {
        _levelText.text = _level.ToString();
    }

    private void SetMaxValue()
    {
        _maxValue *= 2;
    }
}
