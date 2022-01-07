//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerInteraction : MonoBehaviour
//{
//    private int currentStage = 0;
//    [SerializeField] private GameObject magicStaff;
//    private int maskNumber = 0;
//    public int MaskNumber { get => maskNumber; }
//    private bool hasChestKey = false;
//    private bool canEnterPin = false;
//    private IInteractable currentInteraction;
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.TryGetComponent<IInteractable>(out currentInteraction)){
//            currentInteraction.GenerateInteraction();
//        }    
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.TryGetComponent<IInteractable>(out IInteractable interactingObject))
//        {
//            if (interactingObject == currentInteraction)
//            {
//                currentInteraction.ClearInteraction();
//            }
//        }

//    }

//    public void UpdateStats()
//    {
//        switch (currentStage)
//        {
//            case 0:
//                magicStaff.SetActive(true);
//                break;
//            case 1:
//            default:
//                break;
//        }
//        currentStage++;
//    }

//    public bool HasStaff()
//    {
//        return magicStaff.activeSelf;
//    }

//    public void AddMask()
//    {
//        if (maskNumber < 3)
//        {
//            maskNumber++;
//        }
//    }

//    public void AddKey()
//    {
//        hasChestKey = true;
//    }

//    public bool CheckKey()
//    {
//        return hasChestKey;
//    }

//    public void ActivateFinalStage()
//    {
//        canEnterPin = true;
//    }

//    public bool IsFinalStage()
//    {
//        return canEnterPin;
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
