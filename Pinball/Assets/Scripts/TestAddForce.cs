using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddForce : MonoBehaviour
{
    public Vector3 vector;
    public float forceMultiplier;
    public ForceMode fM;
    public void AddForce()
    {
        GetComponent<Rigidbody>().AddForce(vector * forceMultiplier, fM);
    }
}
