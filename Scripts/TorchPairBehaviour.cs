using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPairBehaviour : MonoBehaviour, IChoiceMaker
{
    [SerializeField] private GameObject pinkTorchObject;
    private TorchStartBehaviour pinkTorch;
    [SerializeField] private GameObject greenTorchObject;
    private TorchStartBehaviour greenTorch;
    [SerializeField] private AudioSource selectionChime;
    [SerializeField] private StaffEyeBehaviour staffEyes;
    private bool isComplete = false;
    public int ChoiceValue { get; private set; }

    private void Awake()
    {
        pinkTorch = pinkTorchObject.GetComponent<TorchStartBehaviour>();
        greenTorch = greenTorchObject.GetComponent<TorchStartBehaviour>();
    }

    private void Update()
    {
        tryChooseTorch();
    }

    private void tryChooseTorch()
    {
        if (!isComplete)
        {
            if (pinkTorch.isChosen)
            {
                eliminateTorch(greenTorch);
                staffEyes.ChooseStaffSide(StaffEyeBehaviour.StaffSide.Right);
            }
            if (greenTorch.isChosen)
            {
                eliminateTorch(pinkTorch);
                staffEyes.ChooseStaffSide(StaffEyeBehaviour.StaffSide.Left);
            }
            DetermineChoice();
        }
    }

    private void eliminateTorch(TorchStartBehaviour torchToEliminate)
    {
        torchToEliminate.DeactivateTorch();
        selectionChime.Play();
        isComplete = true;
    }

    public int DetermineChoice()
    {
        if (pinkTorch.isChosen)
        {
            ChoiceValue = pinkTorch.ChoiceId;
        }
        else
        {
            ChoiceValue = greenTorch.ChoiceId;
        }
        return ChoiceValue;
    }
}
