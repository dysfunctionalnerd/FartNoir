using UnityEngine;

public class CharacterInteractionTrigger : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Collider2D levelCollider;

   // private DialogueManager dialogueManager;
    //private bool isInteracting = false;

    private void Start()
    {
            Debug.Log(GetComponent<Collider2D>().name);
    }

    private void Update()
    {
                                 
    }
    private void OnTriggerEnter2D(Collider2D playerCollision) 
    {
        Debug.Log(levelCollider.name);
    }

    private void MovePlayerToPosition()
    {
    
    }
}

