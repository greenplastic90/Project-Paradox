using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderShape : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float lineWidth;
    public Color lineColor;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material.color = lineColor;
        lineRenderer.loop = true;

    }



    // steps are the number of lines needed to simulate a circle, the more steps the more smooth the circle looks
    public void DrawCircle(int steps, float radius)
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

    public void DrawSquare(float size)
    {

        lineRenderer.positionCount = 4;

        float halfSize = size / 2f;

        Vector3 topLeft = new Vector3(-halfSize, halfSize, 0f);
        Vector3 topRight = new Vector3(halfSize, halfSize, 0f);
        Vector3 bottomRight = new Vector3(halfSize, -halfSize, 0f);
        Vector3 bottomLeft = new Vector3(-halfSize, -halfSize, 0f);

        lineRenderer.SetPosition(0, topLeft);
        lineRenderer.SetPosition(1, topRight);
        lineRenderer.SetPosition(2, bottomRight);
        lineRenderer.SetPosition(3, bottomLeft);
    }



    public void DrawRectangle(float width, float height)
    {

        lineRenderer.positionCount = 4;

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

    }



    public void DrawTriangle(float size)
    {

        lineRenderer.positionCount = 3;

        float halfSize = size / 2f;

        Vector3 top = new Vector3(0f, halfSize, 0f);
        Vector3 bottomLeft = new Vector3(-halfSize, -halfSize, 0f);
        Vector3 bottomRight = new Vector3(halfSize, -halfSize, 0f);

        lineRenderer.SetPosition(0, top);
        lineRenderer.SetPosition(1, bottomLeft);
        lineRenderer.SetPosition(2, bottomRight);

    }


}
