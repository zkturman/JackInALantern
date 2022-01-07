using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestChestBehaviour : MonoBehaviour, ICollidable, IInteractable, IChoice
{
    [SerializeField] private string[] dialogueString;
    [SerializeField] private AudioSource collisionSound;
    [SerializeField] private AudioSource interactionSound;
    [SerializeField] private PlayerInteraction player;
    [SerializeField] private DialogueBehaviour dialogueManager;
    private int chestStage = 0;
    public string DialogueString 
    { 
        get => dialogueString[chestStage]; 
        set => dialogueString[chestStage] = value; 
    }
    private bool canOpenChest = false;
    [SerializeField] private int choiceId;
    public int ChoiceId { get => choiceId; }

    public void ClearInteraction()
    {
        dialogueManager.ClearDialogueMessage();
    }

    public void GenerateInteraction()
    {
        checkPlayerKey();
        dialogueManager.SetDialogueMessage(DialogueString);
        if (chestStage == 1)
        {
            canOpenChest = true;
        }
    }

    private void checkPlayerKey()
    {
        if (player.CheckKey() && chestStage == 0)
        {
            chestStage++;
        }
    }

    public void PlayInteractionSound()
    {
        interactionSound.Play();
    }

    public void StartCollision()
    {
        collisionSound.Play();

    }

    public void UpdateOtherStats(GameObject statsToChange)
    {
    }

    public void UpdateThisStats()
    {
        canOpenChest = false;
        chestStage++;
        GetComponent<Animator>().SetTrigger("Open");
        dialogueManager.SetDialogueMessage(DialogueString);
    }

    public bool IsChestOpen()
    {
        return chestStage == 2;
    }

    // Update is called once per frame
    void Update()
    {
        tryOpenChest(); 
    }

    private void tryOpenChest()
    {
        if (chestStage == 1 && canOpenChest)
        {
            if (Input.GetKey(KeyCode.E))
            {
                UpdateThisStats();
                UpdateOtherStats(player.gameObject);
            }
        }
    }
}
