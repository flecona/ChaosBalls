using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int tailSize;

    private SpriteRenderer spriteRenderer;
    private LineRenderer lineRenderer;
    private Rigidbody2D rb2d;
    private List<Vector3> tailPoints;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        tailPoints = new List<Vector3>();
        Color c = Random.ColorHSV(0.0f, 1.0f, 0.8f, 1.0f, 0.8f, 1.0f);
        lineRenderer.startColor = c;
        lineRenderer.endColor = c;
        lineRenderer.material.color = c;
        spriteRenderer.color = c;

        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        tailPoints.Add(transform.position);
        if (tailPoints.Count > tailSize)
        {
            tailPoints.RemoveAt(0);
        }
        lineRenderer.positionCount = tailPoints.Count;
        lineRenderer.SetPositions(tailPoints.ToArray());
    }

    public void ApplyForce(Vector2 force)
    {
        rb2d.AddForce(force);
    }

    public void ApplyColor(Color color)
    {
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.material.color = color;
        spriteRenderer.color = color;
    }
}
