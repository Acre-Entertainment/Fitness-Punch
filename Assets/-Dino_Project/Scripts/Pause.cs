using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public GameControl gameControl;

    public void pauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1 + gameControl.howManyTimesHasTimeBeenBosted * 0.25f;
            isPaused = false;
            gameControl.gamePaused = false;
        } else {
            Time.timeScale = 0;
            isPaused = true;
            gameControl.gamePaused = true;
        }
    }
    public void normalSpeed()
    {
        Time.timeScale = 1;
    }
}
