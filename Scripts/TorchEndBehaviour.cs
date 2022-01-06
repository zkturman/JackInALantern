using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchEndBehaviour : TorchIgniteBehaviour
{
    [SerializeField] private GameObject sittingPumpkinObject;
    [SerializeField] private AudioSource pumpkinLaugh;
    private void ActivateSittingPumpkin()
    {
        SittingPumpkinBehaviour sittingPumpkin = sittingPumpkinObject.GetComponent<SittingPumpkinBehaviour>();
        sittingPumpkin.ActivatePumpkin();
        pumpkinLaugh.Play();
    }

    protected override void tryActivateTorch()
    {
        if (canInteract)
        {
            if (Input.GetKey(KeyCode.E))
            {
                ClearInteraction();
                UpdateThisStats();
                UpdateOtherStats(playerObject);
                ActivateSittingPumpkin();
            }
        }
    }
}
