using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     [SerializeField]
    private float moveSpeed = 5f;

    private Rigidbody2D rigid;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
         // Get the Rigidbody2D component for physics-based movement
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
 // Capture input from the user
        movement.x = Input.GetAxisRaw("Horizontal"); // Left/Right movement
        movement.y = Input.GetAxisRaw("Vertical");   // Up/Down movement

        // Flip sprite based on horizontal movement direction
        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0;
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody for a smooth experience
        rigid.MovePosition(rigid.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
