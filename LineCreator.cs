using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class LineCreator : MonoBehaviour
{
    [SerializeField]
    private float interval;
    private float startTime;
    private float x = 7;
    [SerializeField]
    LineRenderer lr;
    EdgeCollider2D edgeCollider;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        edgeCollider = this.GetComponent<EdgeCollider2D>();
        startTime = Time.time;
        interval = 0.2f;
    }

    void FixedUpdate()
    {
        SetEdgeCollider(lr);
        if (Time.time - startTime > interval)
        {
            
            float y = Random.Range(-1f, 1f);
            lr.SetPosition(++lr.positionCount-1, new Vector3(x, y, 0));
            startTime = Time.time;
            x++;
        }
    }
    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < lineRenderer.positionCount; point++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }

        edgeCollider.SetPoints(edges);
    }
}
