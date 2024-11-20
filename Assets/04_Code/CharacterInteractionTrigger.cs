using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionTrigger : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Transform player;
    public Transform character;
    public float interactionRadius = 1.5f;
    DialogueManager dialogueManager;
    

    private void Start()
    {
        // Find the DialogueManager in the scene
        //dialogueManager = GameObject.FindObjectOfType<dialogueManager>();
    }

    private void Update()
    {
        // Check if characters are within interaction distance
        float distance = Vector3.Distance(player.position, character.position);
            Debug.Log($"{distance} between {player.position} and {character.position}");


        if (distance <= interactionRadius) // && !dialogueManager.IsInDialogue)
        {
            //dialogueManager.StartDialogue();

            Debug.Log("talk");
        }
    
    }

    
}