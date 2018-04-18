using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOver : MonoBehaviour
{
    public SpriteRenderer light;
    public Color white;
    public Color yellow;
    public bool on;
    public RollOver otherRollOver;
    public bool manager;

    private void Start()
    {
        light = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (otherRollOver.on && on && manager)
        {
            StartCoroutine(WaitBeforeShutDown());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (on)
            {
                light.color = white;
                on = !on;
            }
            else
            {
                light.color = yellow;
                on = !on;
            }
        }
    }
    IEnumerator WaitBeforeShutDown()
    {
        otherRollOver.on = false;
        on = false;
        Points.score += 200;
        yield return new WaitForSeconds(1);
        light.color = white;
        otherRollOver.light.color = white;
    }
}
