using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(EnableButton);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(EnableButton);
    }

    private void EnableButton()
    {
        Transform parent = _button.transform.parent;
        parent.gameObject.SetActive(true);
    }
}
