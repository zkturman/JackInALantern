using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlickerBehaviour : MonoBehaviour
{
    [SerializeField]
    [Range(0.8f, 1.2f)]
    private float lightRange = 1f;

    [SerializeField]
    private Color primaryColour;

    [SerializeField]
    private Color secondaryColour;

    private Light currentLight;

    private const float colourChangeRate = 0.05f;
    private bool isFlickering = false;
    private bool isColourTransition = false;

    private void Awake()
    {
        currentLight = this.GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeLightColour();
        flickerLight();
    }

    private void changeLightColour()
    {
        if (!isColourTransition)
        {
            float colourDiceRoll = Random.Range(0f, 1f);
            if (colourDiceRoll < colourChangeRate)
            {
                StartCoroutine(flickerColour());
            }
        }
    }

    private IEnumerator flickerColour()
    {
        isColourTransition = true;
        currentLight.color = secondaryColour;
        yield return new WaitForSeconds(0.1f);
        currentLight.color = primaryColour;
        yield return new WaitForSeconds(0.4f);
        isColourTransition = false;
    }

    private void flickerLight()
    {
        if (!isFlickering)
        {
            StartCoroutine(flickerIntensity());
        }
    }

    private IEnumerator flickerIntensity()
    {
        isFlickering = true;
        currentLight.intensity = Random.Range(0.8f, 1.2f);
        currentLight.range = Random.Range(0.8f, 1.2f) * lightRange;
        yield return new WaitForSeconds(0.1f);
        isFlickering = false;
    }
}
