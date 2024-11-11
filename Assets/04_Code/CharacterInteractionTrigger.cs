using UnityEngine;

public class CharacterInteractionTrigger : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Transform player;
    public Transform character;
    public float interactionDistance = 3f;
    public Vector3 playerTargetPosition;

    private DialogueManager dialogueManager;
    private bool isInteracting = false;

    private void Start()
    {
        // Find the DialogueManager in the scene
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        // Check if characters are within interaction distance
        float distance = Vector2.Distance(player.position, character.position);
            //Debug.Log(distance);


        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.Space) && !isInteracting) // && !dialogueManager.IsInDialogue)
        {
            isInteracting = true;
            MovePlayerToPosition();
            Debug.Log("talk");    
        }
                         
    }

    private void MovePlayerToPosition()
    {
        player.position = playerTargetPosition;
        dialogueManager.StartDialogue();
    }
}

