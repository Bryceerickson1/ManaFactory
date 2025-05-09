using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFader : MonoBehaviour
{
    public float fadeSpeed = 1f;         // Speed of the fade
    public float minIntensity = 0f;      // Minimum light intensity
    public float maxIntensity = 1f;      // Maximum light intensity

    private Light lightComponent;
    private float time;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime * fadeSpeed;
        float intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(time) + 1f) / 2f);
        lightComponent.intensity = intensity;
    }
}