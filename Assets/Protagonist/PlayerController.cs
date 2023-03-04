using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private RenderShape bodyShape;
    public float speed = 5f;

    private Rigidbody2D rb2D;
    private Vector2 moveInput;

    void Start()
    {
        bodyShape = transform.Find("Body").GetComponent<RenderShape>();
        rb2D = GetComponent<Rigidbody2D>();

        // bodyShape.DrawSquare(1);
        // bodyShape.DrawRectangle(1, 2);
        // bodyShape.DrawTriangle(1);
        // bodyShape.DrawCircle(100, 1);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2D.AddForce(movement * speed);
        bodyShape.DrawCircle(15, 2);
    }

    void FixedUpdate()
    {

    }
}
