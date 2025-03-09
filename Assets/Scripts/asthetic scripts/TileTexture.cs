using UnityEngine;

public class TileTexture : MonoBehaviour
{
    public float tileX = 2.0f; // Adjust tiling on X axis
    public float tileY = 2.0f; // Adjust tiling on Y axis
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.mainTextureScale = new Vector2(tileX, tileY);
    }
}