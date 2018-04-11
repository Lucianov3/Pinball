using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceBlock : MonoBehaviour
{
    static Animator entranceBlockAnimator;

    private void Start()
    {
        entranceBlockAnimator = gameObject.transform.parent.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            CloseEntranceBlock();
        }
    }

    public static void CloseEntranceBlock()
    {
            entranceBlockAnimator.SetBool("isOpen", false);
    }
    public static void OpenEntranceBlock()
    {
        entranceBlockAnimator.SetBool("isOpen", true);
    }
}
