using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public bool IsInDialogue {  get; private set; }
    // Start is called before the first frame update
    public void StartDialogue()
    {
        IsInDialogue = true;
        Debug.Log("Dialogue started.");
        // Add logic to display dialogue UI or trigger dialogue events here
    }

    public void EndDialogue()
    {
        IsInDialogue = false;
        Debug.Log("Dialogue ended.");
        // Add logic to hide dialogue UI or complete dialogue events here
    }
}
