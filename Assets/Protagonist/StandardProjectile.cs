using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardProjectile : MonoBehaviour
{
    private RenderShape bodyShape;
    private Rigidbody2D rb2D;
    public float movmentSpeed;
    private Vector3 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bodyShape = transform.Find("Body").GetComponent<RenderShape>();
        bodyShape.ChooseShape("isTriangle");
    }

    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementDirection * movmentSpeed * Time.deltaTime;
    }
}
