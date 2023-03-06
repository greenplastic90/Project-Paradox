using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private RenderShape bodyShape;
    private Rigidbody2D rb2D;
    public GameObject standardProjectilePrefab;
    public float movementSpeed = 5f;
    public float rotateSpeed;

    public bool canMove = true;





    void Start()
    {
        bodyShape = transform.Find("Body").GetComponent<RenderShape>();
        rb2D = GetComponent<Rigidbody2D>();

        // Starting Shape
        bodyShape.ChooseShape("isTriangle");
    }

    void Update()
    {
        if (canMove)
        {
            Movement();
        }

        Abilities();
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

    private void Abilities()
    {
        bool leftMouseClicked = Input.GetButtonDown("Fire1");
        if (leftMouseClicked)
        {
            ShootFromPoints();
        }

        void ShootFromPoints()
        {
            LineRenderer lineRenderer = bodyShape.GetComponent<LineRenderer>();
            int numberOfPoints = lineRenderer.positionCount;
            for (int i = 0; i < numberOfPoints; i++)
            {
                InstantiateProjectile(lineRenderer.GetPosition(i));
            }

        }
        void InstantiateProjectile(Vector3 position)
        {
            // Instantiate a StandardProjectile game object
            GameObject projectile = Instantiate(standardProjectilePrefab, position, transform.rotation);

            // Calculate the direction of the projectile based on the position of the triangle point
            Vector3 direction = (position - transform.position).normalized;

            // Get the projectile's movement script and set its movement direction
            StandardProjectile projectileMovement = projectile.GetComponent<StandardProjectile>();
            projectileMovement.SetMovementDirection(direction);
        }
    }


}
