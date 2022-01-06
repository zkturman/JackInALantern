 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingPumpkinBehaviour : MonoBehaviour, ICollidable, IInteractable
{
    [SerializeField] private AudioSource collideNoise;
    [SerializeField] private AudioSource interactNoise;
    [SerializeField] private string dialogueString;
    [SerializeField] private bool hasMagicStaff;
    [SerializeField] private DialogueBehaviour dialogueManager;
    [SerializeField] private GameObject magicStaff;
    [SerializeField] private Light[] eyeLights;
    [SerializeField] private GameObject startingTorches;
    private GameObject playerObject;
    private bool canCollectStaff = false;
    public string DialogueString 
    { 
        get => dialogueString; 
        set => dialogueString = value; 
    }

    public void GenerateInteraction()
    {
        if (hasMagicStaff)
        {
            dialogueManager.SetDialogueMessage(dialogueString);
            canCollectStaff = true;
        }
    }

    public void ClearInteraction()
    {
        if (dialogueString != null)
        {
            dialogueManager.ClearDialogueMessage();
            canCollectStaff = false;
        }
    }

    public void PlayInteractionSound()
    {
        interactNoise.Play();
    }

    public void StartCollision()
    {
        collideNoise.Play();
    }

    public void UpdateOtherStats(GameObject statsToChange)
    {
        statsToChange.GetComponent<PlayerInteraction>().UpdateStats();
    }

    public void UpdateThisStats()
    {
        canCollectStaff = false;
        hasMagicStaff = false;
    }

    private void Awake()
    {
        if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<DialogueBehaviour>();
        }
        playerObject = FindObjectOfType<PlayerInteraction>().gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        tryCollectStaff();
    }

    private void tryCollectStaff()
    {
        if (canCollectStaff)
        {
            if (Input.GetKey(KeyCode.E))
            {
                ClearInteraction();
                UpdateThisStats();
                UpdateOtherStats(playerObject);
                PlayInteractionSound();
                magicStaff.SetActive(false);
                turnOffEyes();
                startingTorches.SetActive(true);
            }
        }
    }

    private void turnOffEyes()
    {
        foreach(Light eye in eyeLights)
        {
            eye.enabled = false;
        }
    }
}
