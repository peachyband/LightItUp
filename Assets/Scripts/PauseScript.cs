using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = true;
    
    void Start()
    {
        Time.timeScale = 0;    
    }

    // Update is called once per frame
    public void pauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
