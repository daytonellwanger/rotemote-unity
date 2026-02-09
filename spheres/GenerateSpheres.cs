using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{

    public Material baseMaterial;

    private void DeletePrevious()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            DestroyImmediate(child.gameObject);
        }
    }

    public void Generate()
    {
        DeletePrevious();

        for (int i = 0; i < 8000; i++)
        {
            Vector3 position = new(
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f)
            );

            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.SetParent(transform);
            sphere.transform.position = position;

            var size = Random.Range(0.1f, 1f);
            sphere.transform.localScale = new Vector3(
                size,
                size,
                size
            );

            Renderer renderer = sphere.GetComponent<Renderer>();
            if (renderer != null && baseMaterial != null)
            {
                Material sphereMaterial = new(baseMaterial);
                Color color = sphereMaterial.color;
                color.r = Random.Range(0f, 1f);
                sphereMaterial.color = color;
                renderer.material = sphereMaterial;
            }

            GameObject lightObj = new GameObject("Point Light");
            lightObj.transform.SetParent(sphere.transform);
            lightObj.transform.localPosition = new Vector3(0f, 0f, 0f);
            var light = lightObj.AddComponent<Light>();
            light.type = LightType.Point;
            light.range = .2f;
            light.intensity = .1f;
            light.color = Color.white;
        }
    }
}
