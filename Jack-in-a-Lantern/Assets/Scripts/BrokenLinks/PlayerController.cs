//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerController : MonoBehaviour, IControllable
//{
//    private bool paused = false;
//    public bool Paused 
//    { 
//        get => paused;
//        set => paused = value;
//    }
//    public INavigator ControlNavigator { get; set; }

//    public void InteractWithObject(IInteractable objectToInteract)
//    {
//        throw new System.NotImplementedException();
//    }

//    public bool ShouldMoveVertical(out float vertical)
//    {
//        vertical = Input.GetAxis("Vertical");
//        return vertical != 0;
//    }

//    public bool ShouldMoveHorizontal(out float horizontal)
//    {
//        horizontal = Input.GetAxis("Horizontal");
//        return horizontal != 0;
//    }

//    public void MoveKeyPress()
//    {
//        if (!Paused)
//        {
//            if (ShouldMoveVertical(out float vertical))
//            {
//                handleVerticalMoveKey(vertical);
//            }
//            else
//            {
//                ControlNavigator.StopMovement();
//            }
//            ShouldMoveHorizontal(out float horizontal);
//            handleHorizontalMoveKey(horizontal);
//        }
//    }

//    private void handleVerticalMoveKey(float verticalInput)
//    {
//        if (verticalInput > 0)
//        {
//            ControlNavigator.MoveForwardMedium();
//        }
//        else if (verticalInput < 0)
//        {
//            ControlNavigator.MoveBackward();
//        }
//        else
//        {
//            Debug.LogWarning("A zero vertical input was registered when it shouldn't have been.");
//        }
//    }

//    private void handleHorizontalMoveKey(float horizontalInput)
//    {
//        int leftOrRight = System.Math.Sign(horizontalInput);
//        ControlNavigator.RotateObject(leftOrRight);
//    }

//    public void TakeAction(KeyCode keyCode)
//    {
//        throw new System.NotImplementedException();
//    }

//    // Start is called before the first frame update
//    private void Start()
//    {
//        if (TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
//        {
//            ControlNavigator = playerMovement;
//        }
//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        MoveKeyPress();
//    }
//}
