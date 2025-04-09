using UnityEngine;

public class SetVolume : MonoBehaviour
{
    public AudioSource audioSource;
    [Range(0f, 1f)]
    public float volume = 1.0f; // Default full volume

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public void UpdateVolume(float newVolume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(newVolume);
        }
    }
}
