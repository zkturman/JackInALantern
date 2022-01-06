using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable
{
    public INavigator ControlNavigator { get; set; }
    public void InteractWithObject(IInteractable objectToInteract);
    public bool ShouldMoveVertical(out float vertical);
    public bool ShouldMoveHorizontal(out float horizontal);
    public void MoveKeyPress();
    public void TakeAction(KeyCode keyCode);
}
