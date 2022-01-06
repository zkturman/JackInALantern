using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeypadButtonBehaviour : MonoBehaviour, IChoiceMaker
{
    [SerializeField] private AudioSource errorSound;
    [SerializeField] private AudioSource successSound;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject levelPortal;
    private Text keyText;
    private List<int> currentCode = new List<int>();
    [SerializeField] private List<int> correctCode = new List<int>();
    [SerializeField] private List<int> secondaryCorrectCode = new List<int>();
    private int[] defaultCode = { 0, 5, 2, 0 };
    private int[] secondaryCode = { 2, 0, 0, 5 };
    public (Vector3 position, Quaternion rotation) CameraPosition { get; set; }

    public int ChoiceValue { get; private set; }

    private GameObject cameraObject;

    private void Awake()
    {
        if (playerObject == null)
        {
            playerObject = FindObjectOfType<PlayerController>().gameObject;
        }
        keyText = GetComponent<Text>();
        if (correctCode.Count == 0)
        {
            correctCode.AddRange(defaultCode);
        }
        if (secondaryCorrectCode.Count == 0)
        {
            secondaryCorrectCode.AddRange(secondaryCode);
        }
        cameraObject = playerObject.GetComponentInChildren<Camera>().gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PressKey(int keyNumber)
    {
        currentCode.Add(keyNumber);
        if (currentCode.Count == correctCode.Count)
        {
            isValidCode();
        }
    }

    private bool isValidCode()
    {
        bool isCorrectCode = true;
        if (!checkCodeLength() || !checkCodeValues())
        {
            isCorrectCode = false;
            processIncorrectCode();
        }
        return isCorrectCode;
    }

    private bool checkCodeLength()
    {
        return currentCode.Count == correctCode.Count;
    }

    private bool checkCodeValues()
    {
        bool isCorrect = false;
        if (checkCode(correctCode))
        {
            ChoiceValue = 1;
            isCorrect = true;
        }
        if (checkCode(secondaryCorrectCode))
        {
            ChoiceValue = 2;
            isCorrect = true;
        }
        return isCorrect;
    }

    private bool checkCode(List<int> codeToCompare)
    {
        for (int i = 0; i < codeToCompare.Count; i++)
        {
            if (currentCode[i] != codeToCompare[i])
            {
                return false;
            }
        }
        return true;
    }

    private void processIncorrectCode()
    {
        errorSound.Play();
        clearCode();
    }

    private void clearCode()
    {
        currentCode.Clear();
    }

    public void PressEnter()
    {
        if (isValidCode())
        {
            successSound.Play();
            StartCoroutine(disengageCamera());
            GetComponentInParent<Animator>().SetTrigger("Open");
            levelPortal.SetActive(true);
            playerObject.GetComponent<PlayerController>().Paused = false;
            //playerObject.GetComponent<Collider>().enabled = true;
            playerObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    private IEnumerator disengageCamera()
    {
        gameObject.GetComponentInChildren<GraphicRaycaster>().enabled = false;
        Vector3 currentLocation = cameraObject.transform.position;
        Vector3 targetLocation = CameraPosition.position;
        Quaternion currentRotation = cameraObject.transform.rotation;
        Quaternion targetRotation = CameraPosition.rotation;
        float x = 0f;
        while (x < 1f)
        {
            cameraObject.transform.position = Vector3.Lerp(currentLocation, targetLocation, Mathf.SmoothStep(0f, 1f, x));
            cameraObject.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, Mathf.SmoothStep(0f, 1f, x));
            x += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }

    public void PressClear()
    {
        clearCode();
    }

    public int DetermineChoice()
    {
        return ChoiceValue;
    }
}
