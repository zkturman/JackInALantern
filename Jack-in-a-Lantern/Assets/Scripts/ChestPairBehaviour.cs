using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPairBehaviour : MonoBehaviour, IChoiceMaker
{
    [SerializeField] private ForestChestBehaviour[] chestPair = new ForestChestBehaviour[2];
    private bool choiceMade = false;
    public int ChoiceValue { get; private set; }
    private PlayerInteraction player;

    public int DetermineChoice()
    {
        return ChoiceValue;
    }

    private void Awake()
    {
        player = FindObjectOfType<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        checkChoiceMade();
        checkChestStatus();
    }

    private void checkChoiceMade()
    {
        if (!choiceMade)
        {
            if (chestPair[0].IsChestOpen())
            {
                choiceMade = true;
                ChoiceValue = chestPair[0].ChoiceId;

            }
            else if (chestPair[1].IsChestOpen())
            {
                choiceMade = true;
                ChoiceValue = chestPair[1].ChoiceId;
            }
        }
    }

    private void checkChestStatus()
    {
        if (chestPair[0].IsChestOpen() && chestPair[1].IsChestOpen())
        {
            player.ActivateFinalStage();
        }
    }
}
