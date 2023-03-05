using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private RenderShape bodyShape;
    private Rigidbody2D rb2D;
    public float speed = 5f;
    public bool isMoving;




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
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (moveHorizontal != 0)
        {
            isMoving = true;
            rb2D.velocity = new Vector2(moveHorizontal * speed, rb2D.velocity.y);
        }
        else
        {
            isMoving = false;
            rb2D.velocity = Vector2.zero;
        }
    }


}
