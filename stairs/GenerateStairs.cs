using UnityEngine;

public class GenerateStairs : MonoBehaviour
{
    public int stepCount = 150;
    public float stepHeight = 0.1f;
    public float stepDepth = 0.5f;
    public float stepWidth = 0.5f;

    void OnValidate()
    {
        Generate();
    }

    void Generate()
    {
        float radius = 1f;
        float angle = Mathf.PI / 10;
        for (int i = 0; i < stepCount; i++)
        {   
            float x = Mathf.Cos(i * angle) * radius;
            float z = Mathf.Sin(i * angle) * radius;

            Vector3 position = new(
                x,
                i * stepHeight,
                z
            );

            GameObject step = GameObject.CreatePrimitive(PrimitiveType.Cube);
            step.transform.SetParent(transform);
            step.transform.position = position;

            step.transform.localScale = new Vector3(
                stepWidth,
                stepHeight,
                stepDepth
            );
        }
    }
}
