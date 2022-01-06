using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadDoorBehaviour : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject playerObject;
    private GameObject cameraObject;
    [SerializeField] private DialogueBehaviour dialogueManager;
    [SerializeField] private string dialogueString;
    [SerializeField] private AudioSource zoomSound;
    [SerializeField] private GameObject keyPadObject;
    [SerializeField] private GameObject doorEffects;
    [SerializeField] private AudioSource chimeSound;
    private bool doorRisen = false;
    public string DialogueString 
    { 
        get => dialogueString; 
        set => dialogueString = value; 
    }
    private bool canEngageKeypad = false;

    public void ClearInteraction()
    {
        if (dialogueString != null)
        {
            dialogueManager.ClearDialogueMessage();
        }
        canEngageKeypad = false;
    }

    public void GenerateInteraction()
    {
        dialogueManager.SetDialogueMessage(dialogueString);
        canEngageKeypad = true;
    }

    public void PlayInteractionSound()
    {
        zoomSound.Play();
    }

    public void UpdateOtherStats(GameObject statsToChange)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateThisStats()
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        cameraObject = playerObject.GetComponentInChildren<Camera>().gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tryActivateFinalStage();
        tryEngageKeypad();
    }

    private void tryActivateFinalStage()
    {
        if (!doorRisen && playerObject.GetComponent<PlayerInteraction>().IsFinalStage())
        {
            StartCoroutine(activateDoor());
            doorRisen = true;
        }
    }

    private IEnumerator activateDoor()
    {
        GetComponent<Animator>().SetTrigger("Rise");
        yield return new WaitForSeconds(1.5f);
        chimeSound.Play();
        doorEffects.SetActive(true);
    }

    private void tryEngageKeypad()
    {
        if (canEngageKeypad)
        {
            if (Input.GetKey(KeyCode.E))
            {
                playerObject.GetComponent<PlayerController>().Paused = true;
                //playerObject.GetComponent<Collider>().enabled = false;
                playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                StartCoroutine(cameraToKeypad());
                ClearInteraction();
            }
        }
    }

    private IEnumerator cameraToKeypad()
    {
        keyPadObject.GetComponentInChildren<GraphicRaycaster>().enabled = true;
        Vector3 currentLocation = cameraObject.transform.position;
        Vector3 targetLocation = keyPadObject.transform.position - (keyPadObject.transform.forward * 0.5f);
        Quaternion currentRotation = cameraObject.transform.rotation;
        Quaternion targetRotation = keyPadObject.transform.rotation;
        float x = 0f;
        while (x < 1f)
        {
            cameraObject.transform.position = Vector3.Lerp(currentLocation, targetLocation, Mathf.SmoothStep(0f, 1f, x));
            cameraObject.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Mathf.SmoothStep(0f, 1f, x));
            x += Time.deltaTime;
            yield return null;
        }
        keyPadObject.GetComponent<KeypadButtonBehaviour>().CameraPosition = (currentLocation, currentRotation);
        yield return null;
    }
}
