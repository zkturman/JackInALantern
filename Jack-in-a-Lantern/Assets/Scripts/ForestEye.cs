using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEye
{
    private GameObject eyeObject;
    private Light eyeLight;
    private Color eyeColor;
    public Color EyeColor { get => eyeColor; }
    private GameObject eyeBall;
    private Renderer eyeMaterial;
    public Renderer EyeMaterial { get => eyeMaterial; }

    public ForestEye(GameObject eyeObject)
    {
        this.eyeObject = eyeObject;
        eyeLight = eyeObject.GetComponentInChildren<Light>();
        eyeColor = eyeLight.color;
        eyeMaterial = eyeObject.GetComponentInChildren<Renderer>();
    }

    public void UpdateColor(Color newColor)
    {
        eyeLight.color = newColor;
        eyeColor = newColor;
    }

    public void UpdateMaterial(Renderer newMaterial)
    {
        eyeMaterial.material = newMaterial.material;
    }
}
