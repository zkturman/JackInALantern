using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffEyeBehaviour : MonoBehaviour
{


    [SerializeField] private GameObject leftEyeObject;
    [SerializeField] private GameObject rightEyeObject;
    private ForestEye leftEye;
    private ForestEye rightEye;

    private void Awake()
    {
        leftEye = new ForestEye(leftEyeObject);
        rightEye = new ForestEye(rightEyeObject);
    }

    public enum StaffSide
    {
        Left,
        Right
    }

    public void ChooseStaffSide(StaffSide side)
    {
        switch (side)
        {
            case StaffSide.Left:
                updateEyeColour(rightEye, leftEye);
                break;
            case StaffSide.Right:
                updateEyeColour(leftEye, rightEye);
                break;
            default:
                Debug.LogError("Staff side is undefined.");
                break;
        }
    }
    
    private void updateEyeColour(ForestEye eyeToChange, ForestEye newDefinition)
    {
        eyeToChange.UpdateColor(newDefinition.EyeColor);
        eyeToChange.UpdateMaterial(newDefinition.EyeMaterial);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
