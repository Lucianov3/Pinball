using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBumper : MonoBehaviour
{
    public float pointsGained = 100;
    public float forceStrength = 1.2f;
    public MeshRenderer blinkingPart;
    [ColorUsage(false, true, 0, 10, 0, 10)]
    public Color blinkingColor;
    Color notBlinkingColor;
    bool coroutineIsRunning;

    private void Start()
    {
        notBlinkingColor = blinkingPart.material.GetColor("_EmissionColor");
    }

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(-transform.up * forceStrength,ForceMode.Impulse);
        Points.points += pointsGained;
        if (!coroutineIsRunning)
        {
            StartCoroutine(BlinkinkPart());
        }
    }

    IEnumerator BlinkinkPart()
    {
        coroutineIsRunning = true;
        blinkingPart.material.SetColor("_EmissionColor",blinkingColor);
        yield return new WaitForSeconds(0.2f);
        blinkingPart.material.SetColor("_EmissionColor", notBlinkingColor);
        coroutineIsRunning = false;
    }
}
