using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    bool gameIsPaused;
    bool controlsOpen;
    public GameObject Canvas;
    EventSystem es;
    public GameObject ContinueButton;
    public GameObject BackButton;

    private void Start()
    {
        es = EventSystem.current;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Un_PauseGame();
        }
    }

    public void Un_PauseGame()
    {
        if (gameIsPaused)
        {
            gameIsPaused = false;
            Canvas.transform.GetChild(1).gameObject.SetActive(true);
            Canvas.transform.GetChild(2).gameObject.SetActive(true);
            Canvas.transform.GetChild(3).gameObject.SetActive(true);
            Canvas.transform.GetChild(4).gameObject.SetActive(false);
            Canvas.transform.GetChild(5).gameObject.SetActive(false);
            Canvas.SetActive(false);
        }
        else
        {
            gameIsPaused = true;
            controlsOpen = false;
            Canvas.SetActive(true);
            StartCoroutine(highlightButton(Canvas.transform.GetChild(1).gameObject));
        }
    }

    public void Open_CloseControls()
    {
        if (controlsOpen)
        {
            StartCoroutine(highlightButton(Canvas.transform.GetChild(1).gameObject));
            //Canvas.transform.GetChild(1).GetComponent<Button>().Select();
            controlsOpen = false;
            Canvas.transform.GetChild(4).gameObject.SetActive(false);
            Canvas.transform.GetChild(5).gameObject.SetActive(false);
            Canvas.transform.GetChild(1).gameObject.SetActive(true);
            Canvas.transform.GetChild(2).gameObject.SetActive(true);
            Canvas.transform.GetChild(3).gameObject.SetActive(true);
        }
        else
        {
            StartCoroutine(highlightButton(Canvas.transform.GetChild(4).gameObject));
            //Canvas.transform.GetChild(4).GetComponent<Button>().Select();
            controlsOpen = true;
            Canvas.transform.GetChild(4).gameObject.SetActive(true);
            Canvas.transform.GetChild(5).gameObject.SetActive(true);
            Canvas.transform.GetChild(1).gameObject.SetActive(false);
            Canvas.transform.GetChild(2).gameObject.SetActive(false);
            Canvas.transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator highlightButton(GameObject b)
    {
        es.SetSelectedGameObject(null);
        yield return null;
        es.SetSelectedGameObject(b);
    }
    
}
