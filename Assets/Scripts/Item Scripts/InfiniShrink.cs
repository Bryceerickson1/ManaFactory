using UnityEngine;
using System.Collections;

public class SpriteShrinker : MonoBehaviour
{
    [SerializeField]
    private float shrinkSpeed = 0.1f; // Speed at which the sprite shrinks

    private void Start()
    {
        // Start the Shrink coroutine
        StartCoroutine(ShrinkOverTime());
    }

    private IEnumerator ShrinkOverTime()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = Vector3.zero;

        while (transform.localScale.x > 0 && transform.localScale.y > 0 && transform.localScale.z > 0)
        {
            // Gradually reduce the scale of the sprite
            transform.localScale = Vector3.Lerp(originalScale, targetScale, Mathf.PingPong(Time.time * shrinkSpeed, 1));

            // Check if any component of the scale is negative
            if (transform.localScale.x < 0 || transform.localScale.y < 0 || transform.localScale.z < 0)
            {
                // Destroy the GameObject if scale becomes negative
                Destroy(gameObject);
                yield break; // Exit the coroutine
            }

            yield return null;
        }
    }
}
