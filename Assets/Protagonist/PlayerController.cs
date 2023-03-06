using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private RenderShape bodyShape;
    private Rigidbody2D rb2D;
    public float movementSpeed = 5f;
    public float rotateSpeed;





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
        float rotateAmount = Input.GetAxis("Mouse X") * rotateSpeed;

        if (moveHorizontal != 0)
        {
            rb2D.velocity = new Vector2(moveHorizontal * movementSpeed, rb2D.velocity.y);
        }

        if (moveVertical != 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, moveVertical * movementSpeed);
        }

        if (rotateAmount != 0)
        {
            rb2D.rotation -= rotateAmount;
        }
    }



}
