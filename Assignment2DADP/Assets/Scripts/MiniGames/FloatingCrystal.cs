using UnityEngine;

public class FloatingCrystal : MonoBehaviour
{
   
    public float floatHeight = 0.1f;   
    public float floatSpeed = 2f;      
    public float rotationSpeed = 30f;  

    private Vector3 startPos;
    private float startOffset;

    void Start()
    {
        startPos = transform.position;

     
        startOffset = Time.time;
    }

    void Update()
    {
        float globalWave = Mathf.Sin((Time.time - startOffset) * floatSpeed);
        float offset = globalWave * floatHeight;

        transform.position = startPos + Vector3.up * offset;
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }
}
