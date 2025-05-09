using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderByIndex : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    // Call this to load the scene at the specified build index
    public void LoadScene()
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Scene index out of range: " + sceneIndex);
        }
    }
}
