using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderShape : MonoBehaviour
{
    public GameObject parentObject;
    public LineRenderer lineRenderer;
    public float lineWidth;
    public Color lineColor;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineColor = new Color(255, 255, 255);
        lineRenderer.material.color = lineColor;
        lineRenderer.loop = true;
    }

    void Update()
    {

    }



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

            currentPosition = transform.rotation * currentPosition + transform.position;

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

        topLeft = transform.rotation * topLeft + transform.position;
        topRight = transform.rotation * topRight + transform.position;
        bottomRight = transform.rotation * bottomRight + transform.position;
        bottomLeft = transform.rotation * bottomLeft + transform.position;

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

        topLeft = transform.rotation * topLeft + transform.position;
        topRight = transform.rotation * topRight + transform.position;
        bottomRight = transform.rotation * bottomRight + transform.position;
        bottomLeft = transform.rotation * bottomLeft + transform.position;

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

        // Apply rotation around z-axis
        top = transform.rotation * top + transform.position;
        bottomLeft = transform.rotation * bottomLeft + transform.position;
        bottomRight = transform.rotation * bottomRight + transform.position;

        lineRenderer.SetPosition(0, top);
        lineRenderer.SetPosition(1, bottomLeft);
        lineRenderer.SetPosition(2, bottomRight);
    }
    private Vector3 RotateAroundZAxis(Vector3 position, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radian);
        float cos = Mathf.Cos(radian);
        return new Vector3(cos * position.x - sin * position.y, sin * position.x + cos * position.y, position.z);
    }

}
