using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMaskBehaviour : MonoBehaviour, IChoiceMaker
{
    private Animator rotationAnimator;
    [SerializeField] private ForestMaskBehaviour[] maskArray;
    private Dictionary<int, ForestMaskBehaviour> maskLookup = new Dictionary<int, ForestMaskBehaviour>();
    public int ChoiceValue { get; private set; }

    private void Awake()
    {
        foreach(ForestMaskBehaviour mask in maskArray)
        {
            maskLookup.Add(mask.MaskId, mask);
        }
        rotationAnimator = GetComponent<Animator>();
    }

    public void ActivateMask(int maskId)
    {
        ForestMaskBehaviour maskToActivate = maskLookup[maskId];
        maskToActivate.ActivateMask();
        if (rotationAnimator.enabled == false) {
            rotationAnimator.enabled = true;
            ChoiceValue = maskToActivate.ChoiceId;
        }
    }

    public int DetermineChoice()
    {
        return ChoiceValue;
    }
}
