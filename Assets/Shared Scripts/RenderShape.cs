using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderShape : MonoBehaviour
{
    public GameObject parentObject;
    private bool parentIsMoving;
    public LineRenderer lineRenderer;
    public BoxCollider2D boxCollider;
    public CircleCollider2D circleCollider;
    public PolygonCollider2D triangleCollider;
    public float lineWidth;
    public Color lineColor;

    public int circleSteps;
    public float circleRadius;
    public float rectangleLengthX;
    public float rectangleLengthY;

    public float triangleSideLength;

    public Dictionary<string, bool> shapeDict = new Dictionary<string, bool>()
    {
        {"isCircle", false},
        {"isRectangle", false},
        {"isTriangle", false}
    };



    // Start is called before the first frame update
    void Start()
    {




        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineColor = new Color(255, 255, 255);
        lineRenderer.material.color = lineColor;
        lineRenderer.loop = true;
        Debug.Log("Shape Start");


    }

    void Update()
    {
        CheckIfParentIsMoving();
        // Only Draw shapes while movement is happening
        if (parentIsMoving)
        {
            DrawSelectedShape();
        }


    }

    // Shape picked is true the rest are false,
    public void ChooseShape(string key)
    {
        var shapes = new Dictionary<string, bool>(shapeDict);
        foreach (var shape in shapes)
        {
            if (shape.Key == key)
            {
                shapeDict[shape.Key] = true;

            }
            else
            {
                shapeDict[shape.Key] = false;
            }
        }
        DrawSelectedShape();
    }



    private void CheckIfParentIsMoving()
    {
        parentIsMoving = parentObject.GetComponent<PlayerController>().isMoving;
    }

    private void DrawSelectedShape()
    {
        foreach (KeyValuePair<string, bool> shape in shapeDict)
        {
            if (shape.Value)
            {
                if (shape.Key == "isCircle")
                {
                    DrawCircle(circleSteps, circleRadius);
                }
                if (shape.Key == "isRectangle")
                {
                    DrawRectangle(rectangleLengthX, rectangleLengthY);
                }
                if (shape.Key == "isTriangle")
                {
                    DrawTriangle(triangleSideLength);
                }
            }
        }


    }

    public void DrawCircle(int steps, float radius)
    {
        ColliderShape(circleRadius: radius);

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

    public void DrawRectangle(float width, float height)
    {
        ColliderShape(boxX: width, boxY: height);

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
        ColliderShape(triangleSideLength: size);

        lineRenderer.positionCount = 3;

        // Calculate the height of the equilateral triangle
        float height = size * Mathf.Sqrt(3) / 2f;

        Vector3 top = new Vector3(0f, height / 2f, 0f);
        Vector3 bottomLeft = new Vector3(-size / 2f, -height / 2f, 0f);
        Vector3 bottomRight = new Vector3(size / 2f, -height / 2f, 0f);

        // Apply rotation around z-axis
        top = transform.rotation * top + transform.position;
        bottomLeft = transform.rotation * bottomLeft + transform.position;
        bottomRight = transform.rotation * bottomRight + transform.position;

        lineRenderer.SetPosition(0, top);
        lineRenderer.SetPosition(1, bottomLeft);
        lineRenderer.SetPosition(2, bottomRight);
    }


    private void ColliderShape(float circleRadius = 0f, float boxX = 0f, float boxY = 0f, float triangleSideLength = 0f)
    {
        // Disable all colliders
        Collider2D[] colliders = gameObject.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }



        foreach (KeyValuePair<string, bool> shape in shapeDict)
        {
            if (shape.Value)
            {
                if (shape.Key == "isCircle")
                {
                    circleCollider.enabled = true;
                    circleCollider.radius = circleRadius;
                }
                if (shape.Key == "isRectangle")
                {
                    boxCollider.enabled = true;
                    boxCollider.size = new Vector2(boxX, boxY);
                }
                if (shape.Key == "isTriangle")
                {
                    triangleCollider.enabled = true;

                    float height = Mathf.Sqrt(3) / 2 * triangleSideLength;
                    Vector2[] points = new Vector2[3];

                    points[0] = new Vector2(-triangleSideLength / 2, -height / 2);
                    points[1] = new Vector2(triangleSideLength / 2, -height / 2);
                    points[2] = new Vector2(0, height / 2);

                    triangleCollider.points = points;
                }
            }
        }

    }

}
