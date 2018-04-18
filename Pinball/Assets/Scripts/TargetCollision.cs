using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    public bool hit;
    public bool isBlinking;
    Material blinkingMaterial;
    [ColorUsage(false, true, 0, 10, 0, 10)]
    public Color blinkingColor;
    Color notBlinkingColor;

    private void Start()
    {
        blinkingMaterial = GetComponent<MeshRenderer>().material;
        notBlinkingColor = blinkingMaterial.GetColor("_EmissionColor");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")&& !isBlinking)
        {
            hit = !hit;
            SwitchColor();
        }
        
    }
    public void SwitchColor()
    {
        if(blinkingMaterial.GetColor("_EmissionColor") == notBlinkingColor)
        {
            blinkingMaterial.SetColor("_EmissionColor", blinkingColor);
        }
        else
        {
            blinkingMaterial.SetColor("_EmissionColor", notBlinkingColor);
        }
    }

    public void Reset()
    {
        hit = false;
        blinkingMaterial.SetColor("_EmissionColor", notBlinkingColor);
    }
}
