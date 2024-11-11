using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionTrigger : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Transform player;
    public Transform character;
    public float interactionDistance = 1.5f;

    //private DialogueManager dialogueManager;

    private void Start()
    {
        // Find the DialogueManager in the scene
        //dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        // Check if characters are within interaction distance
        float distance = Vector2.Distance(player.position, character.position);
            //Debug.Log(distance);


        if (distance <= interactionDistance) // && !dialogueManager.IsInDialogue)
        {
            //dialogueManager.StartDialogue();

            Debug.Log("talk");
        }
    
    }
}
