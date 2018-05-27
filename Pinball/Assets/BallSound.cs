using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    AudioSource audioSource;
    bool canPlaySound = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canPlaySound)
        {
            canPlaySound = false;
            audioSource.Play();
            StartCoroutine(enableSound(0.5f));
        }
    }
    
    IEnumerator enableSound(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        while (!gameObject.activeSelf)
        {
            yield return new WaitForEndOfFrame();
        }
        canPlaySound = true;
    }
}
