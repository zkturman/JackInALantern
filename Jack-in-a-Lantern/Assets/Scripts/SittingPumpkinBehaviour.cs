using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SittingPumpkinBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioSource interactNoise;
    [SerializeField] private string dialogueString;
    [SerializeField] private string secondaryDialogueString;
    [SerializeField] private Light[] eyeLights;
    [SerializeField] private DialogueBehaviour dialogueManager;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject keyObject;
    public string DialogueString
    {
        get => dialogueString;
        set => dialogueString = value;
    }
    private bool hasCode = true;
    private bool isActive = false;
    private bool canCollectKey = false;


    public void ActivatePumpkin()
    {
        foreach (Light eye in eyeLights)
        {
            eye.enabled = true;
            isActive = true;
        }
    }

    public void GenerateInteraction()
    {
        if (isActive)
        {
            if (playerHasAllMasks())
            {
                dialogueManager.SetDialogueMessage(secondaryDialogueString);
                canCollectKey = true;
            }
            else
            {
                dialogueManager.SetDialogueMessage(dialogueString);
            }
        }

    }

    private bool playerHasAllMasks()
    {
        PlayerInteraction playerStats = playerObject.GetComponent<PlayerInteraction>();
        return playerStats.MaskNumber == 3;
    }

    public virtual void ClearInteraction()
    {
        if (dialogueString != null)
        {
            dialogueManager.ClearDialogueMessage();
        }
    }

    private void deactivatePumpkin()
    {
        foreach (Light eye in eyeLights)
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
        canCollectKey = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tryCollectKey();
    }

    private void tryCollectKey()
    {
        if (canCollectKey)
        {
            if (Input.GetKey(KeyCode.E))
            {
                keyObject.SetActive(true);
                canCollectKey = false;
            }
        }
    }
}
