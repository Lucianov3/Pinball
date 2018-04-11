using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float bumpingForce = 1.2f;
    public float pointsGained = 100;
    Material blinkingMaterial;
    [ColorUsage(false,true,0,10,0,10)]
    public Color blinkingColor;
    Color notBlinkingColor;
    bool coroutineIsRunning;
    


    private void Start()
    {
        blinkingMaterial = transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material;
        notBlinkingColor = blinkingMaterial.GetColor("_EmissionColor");
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(Vector3.Normalize(transform.position - collision.transform.position)*bumpingForce, ForceMode.Impulse);
        Points.points += pointsGained;

        if (!coroutineIsRunning)
        {
            StartCoroutine(BlinkBumper());
        }
    }

    IEnumerator BlinkBumper()
    {
        blinkingMaterial.SetColor("_EmissionColor",blinkingColor);
        coroutineIsRunning = true;
        yield return new WaitForSeconds(0.2f);
        blinkingMaterial.SetColor("_EmissionColor",notBlinkingColor);
        coroutineIsRunning = false;
    }
}
