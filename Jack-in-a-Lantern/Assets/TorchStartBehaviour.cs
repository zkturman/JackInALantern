using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchStartBehaviour : TorchIgniteBehaviour
{
    public bool isChosen = false;

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
