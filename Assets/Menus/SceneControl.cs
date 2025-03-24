using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("Scene to Load")]
    [SerializeField] private Object sceneToLoad;  // Scene Asset to load

    [Header("Key to Trigger Scene Change")]
    [SerializeField] private KeyCode triggerKey = KeyCode.Space;  // Key to trigger scene change

    private void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(triggerKey))
        {
            LoadTargetScene();
        }
    }

    // Load the assigned scene
    private void LoadTargetScene()
    {
        if (sceneToLoad != null)
        {
            string sceneName = GetSceneName(sceneToLoad);

            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("Invalid Scene Asset! Please assign a valid scene.");
            }
        }
        else
        {
            Debug.LogError("Scene Asset is not assigned in the Inspector!");
        }
    }

    // Extract scene name from the assigned asset
    private string GetSceneName(Object sceneAsset)
    {
#if UNITY_EDITOR
        string scenePath = UnityEditor.AssetDatabase.GetAssetPath(sceneAsset);
        return System.IO.Path.GetFileNameWithoutExtension(scenePath);
#else
        return "";
#endif
    }
}
