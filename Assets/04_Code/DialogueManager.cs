using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using Ink.UnityIntegration;


public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue System")]
    public GameObject dialogueBoxPrefab;  // Prefab for the speech bubble
    public Transform playerSpeechAnchor;  // Anchor for player bubbles
    public Transform npcSpeechAnchor;     // Anchor for NPC bubbles
    public Button choiceButton1;          // UI Button for choice 1
    public Button choiceButton2;          // UI Button for choice 2

    [SerializeField]
    InkFile testStory;


    private int currentLine = 0;
    private bool inDialogue = false;
    private bool awaitingChoice = false;

    private Dialogue currentDialogue;  // Holds the current dialogue instance

    public bool IsInDialogue => inDialogue;

    private void Start()
    {
        HideChoices();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue.sentences.Length == 0) return;  // Exit if no dialogue is set

        currentDialogue = dialogue;
        inDialogue = true;
        currentLine = 0;
        ShowNextLine();
    }

    private void ShowNextLine()
    {
        if (awaitingChoice) return;  // Wait if awaiting choice

        if (currentLine < currentDialogue.sentences.Length)
        {
            DisplayDialogue(currentDialogue.name, currentDialogue.sentences[currentLine]);
            currentLine++;
        }
        else if (currentDialogue.choices != null && currentDialogue.choices.Length > 0)
        {
            ShowChoices();
        }
        else
        {
            EndDialogue();
        }
    }

    private void ShowChoices()
    {
        awaitingChoice = true;
        choiceButton1.gameObject.SetActive(true);
        choiceButton2.gameObject.SetActive(true);

        // Set choice button text and listeners based on Dialogue choices
        choiceButton1.GetComponentInChildren<Text>().text = currentDialogue.choices[0].choiceText;
        choiceButton2.GetComponentInChildren<Text>().text = currentDialogue.choices[1].choiceText;
        
        choiceButton1.onClick.AddListener(() => MakeChoice(0));
        choiceButton2.onClick.AddListener(() => MakeChoice(1));
    }

    private void MakeChoice(int choiceIndex)
    {
        HideChoices();

        string[] choiceResponses = currentDialogue.choices[choiceIndex].resultingLines;
        foreach (string line in choiceResponses)
        {
            DisplayDialogue("NPC", line);  // Assuming responses are from the NPC
        }

        EndDialogue();
    }

    private void HideChoices()
    {
        awaitingChoice = false;
        choiceButton1.gameObject.SetActive(false);
        choiceButton2.gameObject.SetActive(false);
        choiceButton1.onClick.RemoveAllListeners();
        choiceButton2.onClick.RemoveAllListeners();
    }

    private void DisplayDialogue(string speakerName, string text)
    {
        GameObject bubble = Instantiate(dialogueBoxPrefab);
        DialogueBubble bubbleScript = bubble.GetComponent<DialogueBubble>();

        // Attach bubble to player or NPC anchor
        if (speakerName == "Player")
        {
            bubble.transform.SetParent(playerSpeechAnchor, false);
        }
        else
        {
            bubble.transform.SetParent(npcSpeechAnchor, false);
        }
        
        bubbleScript.SetText(text);
        bubbleScript.AnimateBubble();
    }

    private void EndDialogue()
    {
        inDialogue = false;
        currentLine = 0;
    }
}
