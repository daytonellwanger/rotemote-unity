using UnityEngine;

public class Translate : MonoBehaviour
{
    public Vector3 translationSpeed = new(1f, 0f, 0f);

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += translationSpeed * Time.deltaTime;
    }
}
