using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletSaveProgress : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(DeletSave);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DeletSave);
    }

    private void DeletSave()
    {
        SaveProgress.DeletSaveProgress();
    }
}
