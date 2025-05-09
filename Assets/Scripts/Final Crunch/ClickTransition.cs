using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class clicktransition : MonoBehaviour
{
    [SerializeField] public string sceneToLoadName;
    
    //public string sceneToLoadName;

    [SerializeField] private float sceneLoadDelay = 2f;
    [SerializeField] private float sceneFadeDuration = 1f;
    [SerializeField] private Image sceneFadeOverlay;

    public void BeginSceneTransition()
    {
        if (!string.IsNullOrEmpty(sceneToLoadName))
        {
            StartCoroutine(PerformSceneTransition());
        }
        else
        {
            Debug.LogWarning("sceneToLoadName is not set.");
        }
    }

    private IEnumerator PerformSceneTransition()
    {
        float elapsed = 0f;
        Color startColor = sceneFadeOverlay.color;

        // Fade to white
        while (elapsed < sceneFadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / sceneFadeDuration);
            sceneFadeOverlay.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Wait a moment before switching scenes
        yield return new WaitForSeconds(sceneLoadDelay);

        SceneManager.LoadScene(sceneToLoadName);
    }
}
