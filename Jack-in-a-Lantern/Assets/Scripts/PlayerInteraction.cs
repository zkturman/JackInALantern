using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private int currentStage = 0;
    [SerializeField] private GameObject magicStaff;
    private IInteractable currentInteraction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out currentInteraction)){
            currentInteraction.GenerateInteraction();
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactingObject))
        {
            if (interactingObject == currentInteraction)
            {
                currentInteraction.ClearInteraction();
            }
        }

    }

    public void UpdateStats()
    {
        switch (currentStage)
        {
            case 0:
                magicStaff.SetActive(true);
                break;
            case 1:
            default:
                break;
        }
        currentStage++;
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
