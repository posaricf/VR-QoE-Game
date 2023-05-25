using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableTimer : MonoBehaviour
{
    private void Start()
    {
        QuizController.OnQuizStarted += ChangeToggleInteractability;
        QuizController.OnQuizEnded += ChangeToggleInteractability;
    }

    private void ChangeToggleInteractability()
    {
        Toggle toggle = gameObject.GetComponent<Toggle>();
        toggle.interactable = !toggle.interactable;
    }
}
