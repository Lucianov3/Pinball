using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeLight : MonoBehaviour
{
    MeshRenderer[] lights;
    [ColorUsage(false, true, 0, 10, 0, 10)]
    public Color blinkingColor;
    [ColorUsage(false, true, 0, 10, 0, 10)]
    public Color notBlinkingColor;
    public float minTimeBetweenBlinks;
    public float maxTimeBetweenBlinks;
    public bool highscoreReached;
    bool didTheHighscoreBlingHappen;

    private void Start()
    {
        lights = new MeshRenderer[transform.childCount];
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i] = transform.GetChild(i).GetComponent<MeshRenderer>();
        }
        StartCoroutine(BlinkLightsInRow());
    }

    IEnumerator BlinkLightsInRow()
    {
        yield return null;
        int i = 0;
        while (true)
        {
            for (int j = 0; j < 4; j++)
            {
                lights[i+j].material.SetColor("_EmissionColor", blinkingColor);
            }
            float blinkTimer = maxTimeBetweenBlinks - ((maxTimeBetweenBlinks - minTimeBetweenBlinks) * (1 - ((Points.highScore - Points.score) / Points.highScore)));
            if(Points.score>= Points.highScore&& !highscoreReached)
            {
                highscoreReached = true;
                StartCoroutine(BlinkAllLights());
                yield return new WaitWhile(() => didTheHighscoreBlingHappen == true);
            }
            else if(Points.score >= Points.highScore)
            {
                blinkTimer = minTimeBetweenBlinks;
            }
            yield return new WaitForSeconds(blinkTimer);
            for (int j = 0; j < 4; j++)
            {
                lights[i+j].material.SetColor("_EmissionColor", notBlinkingColor);
            }
            i +=4;
            if(i == lights.Length)
            {
                i = 0;
            }
        }
    }

    IEnumerator BlinkAllLights()
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (var mesh in lights)
            {
                mesh.material.SetColor("_EmissionColor", blinkingColor);
            }
            yield return new WaitForSeconds(1);
            foreach (var mesh in lights)
            {
                mesh.material.SetColor("_EmissionColor", notBlinkingColor);
            }
            yield return new WaitForSeconds(1);
        }
        didTheHighscoreBlingHappen = true;
    }
}
