using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingPumpkinBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource interactNoise;
    [SerializeField] private string dialogueString;
    [SerializeField] private Light[] eyeLights;
    public string DialogueString 
    { 
        get => dialogueString;
        set => dialogueString = value;
    }
    private bool hasCode = true;
    private bool canCollectCode = false;
    [SerializeField] private DialogueBehaviour dialogueManager;

    public void ActivatePumpkin()
    {
        foreach(Light eye in eyeLights)
        {
            eye.enabled = true;
        }
    }

    public void GenerateInteraction()
    {
        dialogueManager.SetDialogueMessage(dialogueString);
        canCollectCode = true;
    }

    public virtual void ClearInteraction()
    {
        if (dialogueString != null)
        {
            dialogueManager.ClearDialogueMessage();
        }
        deactivatePumpkin();
    }

    private void deactivatePumpkin()
    {
        foreach(Light eye in eyeLights)
        {
            eye.enabled = false;
        }
    }

    public void PlayInteractionSound()
    {
        interactNoise.Play();
    }

    public void UpdateOtherStats(GameObject statsToChange)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateThisStats()
    {
        hasCode = false;
        canCollectCode = false;
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
