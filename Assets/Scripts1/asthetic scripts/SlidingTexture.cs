using UnityEngine;

public class SlidingTexture : MonoBehaviour
{
    public float speedX = 0.5f; // Speed of movement in X direction
    public float speedY = 0.0f; // Speed of movement in Y direction
    private Renderer rend;
    private Vector2 textureOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        textureOffset = rend.material.mainTextureOffset;
    }

    void Update()
    {
        textureOffset.x += speedX * Time.deltaTime;
        textureOffset.y += speedY * Time.deltaTime;
        rend.material.mainTextureOffset = textureOffset;
    }
}