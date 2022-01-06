using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchStartBehaviour : TorchIgniteBehaviour, IChoice
{
    private int torchStage = 0;
    public bool isChosen = false;
    [SerializeField] private string[] dialogueStrings = new string[2];
    public override string DialogueString 
    {
        get => dialogueStrings[torchStage];        
    }
    [SerializeField] private int choiceId;
    [SerializeField] private PlayerInteraction player;

    public int ChoiceId 
    { 
        get => choiceId; 
    }

    public override void GenerateInteraction()
    {
        tryIncreaseStage();
        if (torchStage == 0)
        {
            dialogueManager.SetDialogueMessage(DialogueString);
        }
        if (torchStage > 0 && !interactionComplete)
        {
            dialogueManager.SetDialogueMessage(DialogueString);
            canInteract = true;
        }
    }

    private void tryIncreaseStage()
    {
        if (player.HasStaff() && torchStage == 0)
        {
            torchStage++;
        }
    }

    public override void ClearInteraction()
    {
        base.ClearInteraction();
    }

    public override void UpdateThisStats()
    {
        base.UpdateThisStats();
        isChosen = true;
    }
}
