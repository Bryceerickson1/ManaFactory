using UnityEngine;

public class FloatUI : MonoBehaviour
{
    public float floatSpeed = 1.0f;  // Speed of the floating motion
    public float floatAmount = 10f;  // How high/low it floats
    public bool isVertical = true;   // Float vertically or horizontally

    private RectTransform rectTransform;
    private Vector3 startPosition;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * floatSpeed) * floatAmount;

        if (isVertical)
        {
            rectTransform.anchoredPosition = new Vector3(startPosition.x, startPosition.y + offset, startPosition.z);
        }
        else
        {
            rectTransform.anchoredPosition = new Vector3(startPosition.x + offset, startPosition.y, startPosition.z);
        }
    }
}
