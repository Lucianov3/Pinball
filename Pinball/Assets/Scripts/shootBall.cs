using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.75f, 1) * PlayerController.ballForce, ForceMode.Impulse);
    }
}
