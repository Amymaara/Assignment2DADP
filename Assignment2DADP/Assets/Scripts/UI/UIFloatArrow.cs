using UnityEngine;


public class UIFloatArrow : MonoBehaviour
{
    public float floatHeight = 20f;   
    public float floatSpeed = 2f;     

    private RectTransform rectTransform;
    private Vector2 startPos;
  

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;

    
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        rectTransform.anchoredPosition = startPos + new Vector2(0, offset);
    }
}

