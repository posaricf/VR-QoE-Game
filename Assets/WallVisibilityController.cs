using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WallVisibilityController : MonoBehaviour
{
    public float fadeDuration = 0.5f;
    public float fadeDelay = 0.5f;

    private bool isColliding = false;
    private float fadeTimer = 0f;
    private PostProcessVolume postProcessVolume;
    private Coroutine fadeCoroutine;

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
    }

    private void Update()
    {
        if (isColliding && fadeTimer >= fadeDelay && fadeCoroutine == null)
        {
            fadeCoroutine = StartCoroutine(FadeToBlack());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            isColliding = true;
            fadeTimer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            isColliding = false;
            fadeTimer = 0f;
            StopFadeCoroutine();
        }
    }

    private System.Collections.IEnumerator FadeToBlack()
    {
        yield return new WaitForSeconds(fadeDelay);

        float initialWeight = postProcessVolume.weight;
        float targetWeight = 1f;

        while (fadeTimer < fadeDuration)
        {
            fadeTimer += Time.deltaTime;
            float normalizedTime = fadeTimer / fadeDuration;
            postProcessVolume.weight = Mathf.Lerp(initialWeight, targetWeight, normalizedTime);
            yield return null;
        }

        fadeCoroutine = null;
    }

    private void StopFadeCoroutine()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            fadeCoroutine = null;
        }
    }
}
