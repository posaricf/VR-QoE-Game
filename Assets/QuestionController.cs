using System;
using System.Linq;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public static Action<int[]> OnNewPageOrder;

    private void OnEnable()
    {
        QuizController.OnGenerateNewOrder += GenerateRandomOrder;
    }

    private void OnDisable()
    {
        QuizController.OnGenerateNewOrder -= GenerateRandomOrder;
    }

    private static void GenerateRandomOrder()
    {
        System.Random random = new System.Random();
        int[] numbers = Enumerable.Range(0, 10).ToArray();
        int[] randomOrder = numbers.OrderBy(x => random.Next()).ToArray();
        OnNewPageOrder?.Invoke(randomOrder);
    }
}
