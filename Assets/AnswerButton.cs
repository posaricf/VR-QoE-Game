using System;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [Header("Local References")]
    [SerializeField] private Button _button;
    [SerializeField] private Text _text;

    [Header("Settings")]
    [SerializeField] private Color _correctColor;
    [SerializeField] private Color _invalidColor;

    public static Action<string> OnAnswerClicked;
    public static Action OnNextQuestion;

    private bool _valid;

    private void OnEnable()
    {
        _button.onClick.AddListener(AnswerButtonClicked);
        AnswerController.OnAnswerValidity += SetValidity;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(AnswerButtonClicked);
        AnswerController.OnAnswerValidity -= SetValidity;
    }

    /// <summary>
    /// Toggles button interactability.
    /// </summary>
    /// <param name="toggleValue">True if interactable, false otherwise.</param>
    public void ToggleButtonInteractability(bool toggleValue)
    {
        _button.interactable = toggleValue;
    }

    /// <summary>
    /// Paints the button and invokes an event when an answer button is clicked.
    /// </summary>
    private void AnswerButtonClicked()
    {
        OnAnswerClicked?.Invoke(_text.text);
        PaintButtonBackground();
        OnNextQuestion?.Invoke();
    }

    private void SetValidity(bool validity)
    {
        _valid = validity;
    }

    private void PaintButtonBackground()
    {
        _button.image.color = (_valid ? _correctColor : _invalidColor);
    }
}
