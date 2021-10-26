using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollidable
{
    public void UpdateThisStats();
    public void UpdateOtherStats(GameObject statsToChange);
    public void PlayCollideSound();
}
