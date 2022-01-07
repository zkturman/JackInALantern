using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBehaviour : MonoBehaviour
{
    public string DialogueMessage { get; private set; }
    private TextMeshProUGUI dialogueComponent;
    private Animator dialogueAnimator;

    private void Awake()
    {
        dialogueComponent = this.GetComponentInChildren<TextMeshProUGUI>();
        dialogueAnimator = this.GetComponent<Animator>();
        dialogueComponent.text = "";
    }

    public void SetDialogueMessage(string newMessage)
    {
        IEnumerator fadeRoutine = fadeDialogue("Enter");
        dialogueComponent.text = newMessage;
        StartCoroutine(fadeRoutine);
    }
    private IEnumerator fadeDialogue(string trigger)
    {
        dialogueAnimator.SetTrigger(trigger);
        yield return null;
    }

    private IEnumerator fadeOutDialogue(string trigger)
    {
        yield return fadeDialogue(trigger);
        dialogueComponent.text = "";
    }

    public void ClearDialogueMessage()
    {
        IEnumerator fadeRoutine = fadeOutDialogue("Exit");
        StartCoroutine(fadeRoutine);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
