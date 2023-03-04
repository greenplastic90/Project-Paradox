using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderShape : MonoBehaviour
{
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //  DrawCircle(500, 1);
        // DrawSquare(3);
        // DrawRectangle(3, 5);
        DrawTriangle(3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DrawCircle(int steps, float radius)
    {
        lineRenderer.positionCount = steps;

        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0);

            lineRenderer.SetPosition(currentStep, currentPosition);
        }
    }

    void DrawSquare(float size)
    {
        lineRenderer.positionCount = 5;

        float halfSize = size / 2f;

        Vector3 topLeft = new Vector3(-halfSize, halfSize, 0f);
        Vector3 topRight = new Vector3(halfSize, halfSize, 0f);
        Vector3 bottomRight = new Vector3(halfSize, -halfSize, 0f);
        Vector3 bottomLeft = new Vector3(-halfSize, -halfSize, 0f);

        lineRenderer.SetPosition(0, topLeft);
        lineRenderer.SetPosition(1, topRight);
        lineRenderer.SetPosition(2, bottomRight);
        lineRenderer.SetPosition(3, bottomLeft);
        lineRenderer.SetPosition(4, topLeft);
    }

    void DrawRectangle(float width, float height)
    {
        lineRenderer.positionCount = 5;

        float halfWidth = width / 2f;
        float halfHeight = height / 2f;

        Vector3 topLeft = new Vector3(-halfWidth, halfHeight, 0f);
        Vector3 topRight = new Vector3(halfWidth, halfHeight, 0f);
        Vector3 bottomRight = new Vector3(halfWidth, -halfHeight, 0f);
        Vector3 bottomLeft = new Vector3(-halfWidth, -halfHeight, 0f);

        lineRenderer.SetPosition(0, topLeft);
        lineRenderer.SetPosition(1, topRight);
        lineRenderer.SetPosition(2, bottomRight);
        lineRenderer.SetPosition(3, bottomLeft);
        lineRenderer.SetPosition(4, topLeft);
    }

    void DrawTriangle(float size)
    {
        lineRenderer.positionCount = 4;

        float halfSize = size / 2f;

        Vector3 top = new Vector3(0f, halfSize, 0f);
        Vector3 bottomLeft = new Vector3(-halfSize, -halfSize, 0f);
        Vector3 bottomRight = new Vector3(halfSize, -halfSize, 0f);

        lineRenderer.SetPosition(0, top);
        lineRenderer.SetPosition(1, bottomLeft);
        lineRenderer.SetPosition(2, bottomRight);
        lineRenderer.SetPosition(3, top);
    }

}
