using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Renderer))]
public class Gravity : MonoBehaviour
{
    [SerializeField] public GameObject planet;
    [SerializeField] public float attraction = 1f;
    [SerializeField] public LineRenderer line;
    [SerializeField] public float lineInterval = 0.05f;
    [SerializeField] public Camera clippingCamera;

    private float timer = 0f;

    private Vector3 velocity;

    private LineRenderer currentLine;
    private readonly List<Vector3> linePositions = new();
    private float lineTimer = 0f;

    private Plane[] frustumPlanes;

    private bool IsVisible()
    {
        frustumPlanes ??= GeometryUtility.CalculateFrustumPlanes(clippingCamera);
        return GeometryUtility.TestPlanesAABB(frustumPlanes, GetComponent<Renderer>().bounds);
    }

    private void Reset()
    {
        timer = 0f;
        transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        velocity = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        linePositions.Clear();
        lineTimer = 0f;
        currentLine = Instantiate(line, transform.parent);
        currentLine.positionCount = 0;
    }

    void Start()
    {
        Reset();
    }

    private void UpdateLine()
    {
        lineTimer += Time.deltaTime;

        if (lineTimer >= lineInterval)
        {
            lineTimer -= lineInterval;
            linePositions.Add(transform.position);
            currentLine.positionCount = linePositions.Count;
            currentLine.SetPositions(linePositions.ToArray());
        }
    }

    void Update()
    {
        UpdateLine();
        timer += Time.deltaTime;

        if (!IsVisible())
        {
            Reset();
        }

        if (timer >= 90f)
        {
            Reset();
        }

        if (Time.time > 600f)
        {
            planet.GetComponent<Renderer>().enabled = false;
        }

        Vector3 toPlanet = planet.transform.position
                                - transform.position;
        float distanceSq = toPlanet.sqrMagnitude;
        Vector3 acceleration = attraction / distanceSq
                                * toPlanet.normalized;
        transform.position += velocity * Time.deltaTime;
        velocity += acceleration * Time.deltaTime;
    }
}
