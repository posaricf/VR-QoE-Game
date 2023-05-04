using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> _textFields;

    private void OnEnable()
    {
        SocketManager.OnUpdateScore += UpdateScore;
        SocketManager.OnResetScore += ResetScore;
    }

    private void OnDisable()
    {
        SocketManager.OnUpdateScore -= UpdateScore;
        SocketManager.OnResetScore -= ResetScore;
    }

    private void UpdateScore(int scoreboardId, int incorrectAnswers)
    {
        TextMeshProUGUI textField = _textFields[scoreboardId];
        if (incorrectAnswers > 0)
        {
            textField.text = string.Format("To?no: {0}/4\n\nPregledajte pitanja ponovno!", 4 - incorrectAnswers);
        }
        else
        {
            textField.text = "To?no: 4/4\n\nOtvorena vrata sljede?e prostorije!";
        }
    }

    private void ResetScore(int scoreboardId)
    {
        if (_textFields[scoreboardId].text != string.Empty)
        {
            _textFields[scoreboardId].text = string.Empty;
        }
    }
}
