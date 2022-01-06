using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, INavigator
{
    private Rigidbody playerRigidbody;
    [SerializeField]
    [Range(-1f, 1f)]
    private float gravityFactor = 0;
    private float gravityForce; 
    [SerializeField] private float movementSpeed;
    public float MovementSpeed 
    { 
        get => movementSpeed; 
        set => movementSpeed = value; 
    }
    [SerializeField] private float rotationSpeed;
    public float RotationSpeed
    {
        get => rotationSpeed;
        set => rotationSpeed = value;
    }

    public void MoveBackward()
    {
        Vector3 backwardMovement = transform.forward * MovementSpeed * -1;
        backwardMovement.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = backwardMovement;
        playerRigidbody.AddForce(new Vector3(0, gravityForce, 0), ForceMode.Acceleration);
    }

    public void MoveForwardFast()
    {
        throw new System.NotImplementedException();
    }

    public void MoveForwardMedium()
    {
        Vector3 forwardMovement = transform.forward * MovementSpeed;
        forwardMovement.y = playerRigidbody.velocity.y;
        playerRigidbody.velocity = forwardMovement;
        playerRigidbody.AddForce(new Vector3(0, gravityForce, 0), ForceMode.Acceleration);
    }

    public void MoveForwardSlow()
    {
        throw new System.NotImplementedException();
    }

    public void RotateObject(int direction)
    {
        Vector3 eulerRotation = direction * new Vector3(0, RotationSpeed, 0);
        //Quaternion playerRotation = Quaternion.Euler(eulerRotation * Time.fixedDeltaTime);
        //playerRigidbody.MoveRotation(playerRigidbody.rotation * playerRotation);
        transform.Rotate(eulerRotation * Time.deltaTime, Space.Self);
    }

    public void StopMovement()
    {
        Vector3 stopMovement = new Vector3(0, playerRigidbody.velocity.y, 0);
        playerRigidbody.AddForce(new Vector3(0, gravityForce, 0), ForceMode.Acceleration);
    }

    public void StrafeTo()
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        gravityForce = -5 + (-gravityFactor * 10);
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
