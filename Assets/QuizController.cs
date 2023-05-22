using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    [SerializeField] private Button _shuffleButton;
    [SerializeField] private GameObject _landingPage;
    [SerializeField] private GameObject _finalPage;
    [SerializeField] private List<GameObject> _quizPages;

    public static Action OnGenerateNewOrder;
    public static Action<GameObject> OnDelegateAnswerButtons;

    private int[] _questionOrder;
    private int _currentPageNo = 0;

    private void OnEnable()
    {
        _shuffleButton?.onClick.AddListener(SetNewQuestionOrder);
        QuestionController.OnNewPageOrder += SetQuestionOrder;
        AnswerButton.OnNextQuestion += EnableNextQuestion;
    }

    private void OnDisable()
    {
        _shuffleButton?.onClick.RemoveListener(SetNewQuestionOrder);
        QuestionController.OnNewPageOrder -= SetQuestionOrder;
        AnswerButton.OnNextQuestion -= EnableNextQuestion;
    }

    private void SetNewQuestionOrder()
    {
        OnGenerateNewOrder?.Invoke();
    }

    private void SetQuestionOrder(int[] newPageOrder)
    {
        _questionOrder = newPageOrder;
        ShowNextQuestion(_landingPage, _quizPages[newPageOrder[_currentPageNo]]);
    }

    private void ShowNextQuestion(GameObject currentPage, GameObject nextPage)
    {
        currentPage.SetActive(false);
        nextPage.SetActive(true);
    }

    private void EnableNextQuestion()
    {
        GameObject currentPage = _quizPages[_questionOrder[_currentPageNo]];
        GameObject nextButtonObject = currentPage.transform.Find("NextBtn").gameObject;

        Button nextButton = nextButtonObject.GetComponent<Button>();

        nextButtonObject.SetActive(true);
        nextButton.onClick.AddListener(NextQuestion);
    }

    private void NextQuestion()
    {
        GameObject currentPage = _quizPages[_questionOrder[_currentPageNo]];

        if (_currentPageNo < _quizPages.Count - 1)
        {
            GameObject nextPage = _quizPages[_questionOrder[_currentPageNo + 1]];
            ShowNextQuestion(currentPage, nextPage);
            _currentPageNo++;
        }
        else
        {
            ShowNextQuestion(currentPage, _finalPage);
            QuizEnding();
        }
    }

    private void QuizEnding()
    {
        GameObject descriptionObject = _finalPage.transform.Find("Description").gameObject;
        var description = descriptionObject.GetComponent<TextMeshPro>();
        
        description.text = string.Format("Rezultat: {0}/{1}", AnswerController.GetScore(), _quizPages.Count);
        description.fontSize = 300;
    }
}
