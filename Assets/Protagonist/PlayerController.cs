using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private RenderShape bodyShape;
    private Rigidbody2D rb2D;
    public float speed = 5f;





    void Start()
    {
        bodyShape = transform.Find("Body").GetComponent<RenderShape>();
        rb2D = GetComponent<Rigidbody2D>();

        // Starting Shape
        bodyShape.ChooseShape("isTriangle");
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0)
        {
            rb2D.velocity = new Vector2(moveHorizontal * speed, rb2D.velocity.y);
        }

        if (moveVertical != 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, moveVertical * speed);
        }

    }


}
