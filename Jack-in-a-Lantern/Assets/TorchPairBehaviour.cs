using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchPairBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject pinkTorchObject;
    private TorchStartBehaviour pinkTorch;
    [SerializeField] private GameObject greenTorchObject;
    private TorchStartBehaviour greenTorch;
    [SerializeField] private AudioSource selectionChime;
    private bool isComplete = false;

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
            }
            if (greenTorch.isChosen)
            {
                eliminateTorch(pinkTorch);
            }
        }
    }

    private void eliminateTorch(TorchStartBehaviour torchToEliminate)
    {
        torchToEliminate.DeactivateTorch();
        selectionChime.Play();
        isComplete = true;
    }
}
