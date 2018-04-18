using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    TargetCollision target0;
    TargetCollision target1;
    TargetCollision target2;

    private void Start()
    {
        target0 = transform.GetChild(0).GetComponent<TargetCollision>();
        target1 = transform.GetChild(1).GetComponent<TargetCollision>();
        target2 = transform.GetChild(2).GetComponent<TargetCollision>();
    }

    private void Update()
    {
        if (target0.hit && target1.hit && target2.hit)
        {
            StartCoroutine(TargetBlinking());
            target0.hit = false;
            target1.hit = false;
            target2.hit = false;
        }
    }

    IEnumerator TargetBlinking()
    {
        target0.isBlinking = true;
        target1.isBlinking = true;
        target2.isBlinking = true;
        yield return new WaitForSeconds(0.5f);
        Points.score += 300;
        SwitchAllColors();
        yield return new WaitForSeconds(0.5f);
        SwitchAllColors();
        yield return new WaitForSeconds(0.5f);
        SwitchAllColors();
        target0.isBlinking = false;
        target1.isBlinking = false;
        target2.isBlinking = false;
    }

    public void TargetReset()
    {
        target0.Reset();
        target1.Reset();
        target2.Reset();
    }

    void SwitchAllColors()
    {
        target0.SwitchColor();
        target1.SwitchColor();
        target2.SwitchColor();
    }
}
