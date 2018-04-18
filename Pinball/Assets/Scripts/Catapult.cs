using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public Transform[] ballOutputs;
    public GameObject[] ballOutputLights;
    int ballOutputIndex;
    public float catapultPower;

    private void Start()
    {
        StartCoroutine(CatapultOutputSwitcher());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            StartCoroutine(CatapultBall(other.gameObject));
        }
    }

    public IEnumerator CatapultBall(GameObject ball)
    {
        Points.points += 500;
        ball.SetActive(false);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(2f);
        if (!PlayerController.isResetting)
        {
            ball.transform.position = ballOutputs[ballOutputIndex].position;
            ball.SetActive(true);
            rb.AddForce(ballOutputs[ballOutputIndex].forward*catapultPower,ForceMode.Impulse);
        }
    }

    IEnumerator CatapultOutputSwitcher()
    {
        while (true)
        {
            ballOutputIndex = 0;
            ballOutputLights[0].SetActive(true);
            ballOutputLights[1].SetActive(false);
            ballOutputLights[2].SetActive(false);
            yield return new WaitForSeconds(1);
            ballOutputIndex = 1;
            ballOutputLights[0].SetActive(false);
            ballOutputLights[1].SetActive(true);
            ballOutputLights[2].SetActive(false);
            yield return new WaitForSeconds(1);
            ballOutputIndex = 2;
            ballOutputLights[0].SetActive(false);
            ballOutputLights[1].SetActive(false);
            ballOutputLights[2].SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }
    void De_ActivateLights(int index)
    {
        for (int i = 0; i < ballOutputLights.Length; i++)
        {
            if(i == index)
            {
                ballOutputLights[i].SetActive(true);
            }
            else
            {
                ballOutputLights[i].SetActive(false);
            }
        }
    }
}
