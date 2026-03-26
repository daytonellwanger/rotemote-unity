using UnityEngine;

public class RotateAbout : MonoBehaviour
{
    [SerializeField] public Vector3 origin;
    [SerializeField] public float rotationSpeed = 90f;

    void Update()
    {
        transform.RotateAround(origin, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
