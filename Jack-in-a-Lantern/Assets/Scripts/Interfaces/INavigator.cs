using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INavigator
{
    public float MovementSpeed { get; set; }
    public float RotationSpeed { get; set; }
    public void MoveForwardSlow();
    public void MoveForwardMedium();
    public void MoveForwardFast();
    public void StrafeTo();
    public void MoveBackward();
    public void StopMovement();
    public void RotateObject(int direction);
}
