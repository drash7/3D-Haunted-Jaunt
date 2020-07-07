using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{

    private bool isPlayerAtExit = false;
    private bool isPlayerCaught = false;

    public GameObject player;
    public CanvasGroup exitScreen;
    public CanvasGroup caughtScreen;
    
    public float fadeDuration = 1f;
    public float displayDuration = 1f;
    private float timer = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitScreen, false);
        }
        if (isPlayerCaught)
        {
            EndLevel(caughtScreen, true);
        }
    }

    public void CaughtPlayer()
    {
        isPlayerCaught = true;
    }

    private void EndLevel(CanvasGroup canvasGroup, bool doRestart)
    {
        timer += Time.deltaTime;
        canvasGroup.alpha = timer / fadeDuration;
        if (timer > fadeDuration + displayDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
