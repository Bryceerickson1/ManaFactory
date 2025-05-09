using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Image))]
public class FadeOutImageOnStart : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;

    private Image img;

    private void Awake()
    {
        img = GetComponent<Image>();

        // Ensure fully visible at start
        Color c = img.color;
        c.a = 1f;
        img.color = c;
    }

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float time = 0f;
        Color originalColor = img.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            img.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        img.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }
}
