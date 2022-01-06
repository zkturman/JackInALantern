using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string DialogueString { get; set; }
    public void GenerateInteraction();
    public void ClearInteraction();
    public void PlayInteractionSound();
    public void UpdateThisStats();
    public void UpdateOtherStats(GameObject statsToChange);
}
