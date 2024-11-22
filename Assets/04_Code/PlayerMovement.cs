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

    string npcInRadius; 

    [SerializeField]
    LayerMask npcLayer;

    public bool inDialogue;

    // Start is called before the first frame updates
    void Start()
    {
         // Get the Rigidbody2D composnent for physics-based movement
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();       
    }

    // Update is called once per frame
    void Update()
    {
 // Capture input from the user
        movement.x = Input.GetAxisRaw("Horizontal"); // Left/Right movement
        
        // Flip sprite based on horizontal movement direction
        if (movement.x != 0)
        {
            spriteRenderer.flipX = movement.x < 0;
        }

        if (!inDialogue)
        {
            rigid.velocity = new Vector2(movement.x, rigid.velocity.y);
        }

       /* if (Input.GetKeyDown(KeyCode.Space) && CloseToNPC() && !inDialogue)
        {
           // dialogueManager.InitializeDialogue(npcInRadius);
            inDialogue = true;
        }*/
    }

    void FixedUpdate()
    {
        // Apply movement to the Rigidbody for a smooth experience
        rigid.MovePosition(rigid.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

   /* bool CloseToNPC()
    {
       // Collider2D hit = Physiscs2D.OverlapCircle(this.transform.position, interactionRadius, npcLayer);
        if (hit != null)
        {
            npcInRadius = hit.name;
            return true;
        }
        return false;
    }*/
}