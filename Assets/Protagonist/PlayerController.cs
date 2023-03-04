using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private RenderShape bodyShape;
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        bodyShape = transform.Find("Body").GetComponent<RenderShape>();
        rb = GetComponent<Rigidbody2D>();

        // bodyShape.DrawSquare(1);
        // bodyShape.DrawRectangle(1, 2);
        // bodyShape.DrawTriangle(1);
        bodyShape.DrawCircle(200, 2);
    }

    void Update()
    {
        // Get input from keyboard or controller
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        // Move player based on input
        Vector2 moveVelocity = moveInput.normalized * speed;
        rb.velocity = moveVelocity;
    }
}
