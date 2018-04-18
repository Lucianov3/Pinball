using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public int counter;
    public float pointsGained = 100;
    [ColorUsage(false, true, 0, 10, 0, 10)]
    public Color blinkingColor;
    Color notBlinkingColor;
    public MeshRenderer blinkingPart;
    bool coroutineIsRunning;
    public Quaternion startRotation;

    private void Start()
    {
        notBlinkingColor = blinkingPart.material.GetColor("_EmissionColor");
        if (PlayerController.spinners == null)
        {
            PlayerController.spinners = new List<GameObject>();
        }
        PlayerController.spinners.Add(gameObject);
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if(counter > 4)
        {
            Points.score += pointsGained;
            counter = 0;
            if (!coroutineIsRunning)
            {
                StartCoroutine(BlinkinkPart());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spinner"))
        {
            counter++;
        }
    }

    IEnumerator BlinkinkPart()
    {
        coroutineIsRunning = true;
        blinkingPart.material.SetColor("_EmissionColor", blinkingColor);
        yield return new WaitForSeconds(0.2f);
        blinkingPart.material.SetColor("_EmissionColor", notBlinkingColor);
        coroutineIsRunning = false;
    }
}
