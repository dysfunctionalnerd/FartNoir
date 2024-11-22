using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionTrigger : MonoBehaviour
{
    [Header("Interaction Settings")]
    public Transform player;
    public Transform character;
    public float interactionRadius = 1.5f;

    [SerializeField]
    DialogueManager dialogueManager;

    [SerializeField]
    GameObject visualCue;


    private void Start()
    {

        if (visualCue != null)
        {
            visualCue.SetActive(false);
        }
        else
        {
            Debug.LogError("Visual Cue is not assigned in the Inspector!");
        }

    }

    private void Update()
    {
        // Check if characters are within interaction distance
        float distance = Vector3.Distance(player.position, character.position);

        //Debug.Log($"{distance} between {player.position} and {character.position}");


        if (distance <= interactionRadius) // && !dialogueManager.IsInDialogue)
        {
            //dialogueManager.StartDialogue();


            if (visualCue != null && !visualCue.activeSelf)
            {
                Debug.Log("Enabling visual cue.");
                visualCue.SetActive(true);
            }

            if (Input.GetAxisRaw("Submit") > 0 && dialogueManager != null && !dialogueManager.IsInDialogue)
            {
                Debug.Log("Player interacting with NPC.");
                dialogueManager.StartDialogue();
            }

        }

        else
        {
            // if out of interaction radius, hide the visual cue
            if (visualCue != null && visualCue.activeSelf)
            {
                visualCue.SetActive(false);
                Debug.Log("Disabling visual cue.");
            }
        }


        

    }


}