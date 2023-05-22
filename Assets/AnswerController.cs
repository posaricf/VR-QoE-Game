using System;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    [SerializeField] private List<string> _correctAnswers;

    public static Action<bool> OnAnswerValidity;

    private static int _score = 0;

    private void OnEnable()
    {
        AnswerButton.OnAnswerClicked += CheckAnswer;
    }

    private void OnDisable()
    {
        AnswerButton.OnAnswerClicked -= CheckAnswer;
    }

    private void CheckAnswer(string answer)
    {
        if (_correctAnswers.Contains(answer))
        {
            OnAnswerValidity?.Invoke(true);
            _score++;
        }
        else
        {
            OnAnswerValidity?.Invoke(false);
        }
    }

    public static int GetScore()
    {
        return _score;
    }
}
