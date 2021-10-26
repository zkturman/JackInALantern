using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchIgniteBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] protected Animator torchAnimator;
    [SerializeField] protected Light torchLightSource;
    [SerializeField] protected AudioSource interactNoise;
    [SerializeField] protected DialogueBehaviour dialogueManager;
    [SerializeField] protected string dialogueString;
    [SerializeField] protected TorchIgniteBehaviour nextTorch;
    protected GameObject playerObject;
    public string DialogueString 
    { 
        get => dialogueString; 
        set => dialogueString = value; 
    }
    protected bool canInteract = false;
    private bool interactionComplete = false;
    protected virtual void igniteTorch()
    {

    }

    public virtual void ActivateTorch()
    {
        StartCoroutine(raiseTorchRoutine());
    }

    private IEnumerator raiseTorchRoutine()
    {
        torchAnimator.Play("Raise");
        yield return new WaitForSeconds(1f);
        PlayInteractionSound();
        torchLightSource.enabled = true;
    }

    public void DeactivateTorch()
    {
        torchLightSource.enabled = false;
        torchAnimator.Play("Lower");
    }

    public void GenerateInteraction()
    {
        if (!interactionComplete)
        {
            dialogueManager.SetDialogueMessage(DialogueString);
            canInteract = true;
        }
    }

    public virtual void ClearInteraction()
    {
        if (dialogueString != null)
        {
            dialogueManager.ClearDialogueMessage();
            canInteract = false;
        }
    }

    public void PlayInteractionSound()
    {
        interactNoise.Play();
    }

    public virtual void UpdateThisStats()
    {
        canInteract = false;
        interactionComplete = true;
    }

    public void UpdateOtherStats(GameObject statsToChange)
    {
        statsToChange.GetComponent<PlayerInteraction>().UpdateStats();
    }

    private void Awake()
    {
        if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<DialogueBehaviour>();
        }
        playerObject = FindObjectOfType<PlayerInteraction>().gameObject;
        if (torchAnimator == null)
        {
            torchAnimator = GetComponent<Animator>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tryActivateTorch();
    }

    protected virtual void tryActivateTorch()
    {
        if (canInteract)
        {
            if (Input.GetKey(KeyCode.E))
            {
                ClearInteraction();
                UpdateThisStats();
                UpdateOtherStats(playerObject);
                nextTorch.ActivateTorch();
            }
        }
    }

}
