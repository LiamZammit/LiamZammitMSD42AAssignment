using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
    IEnumerator winWaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Win");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("SimpleCarGame");
        GameSession gs = FindObjectOfType<GameSession>();
        if (gs != null)
        {
            //reset the Game from the beginning
            gs.ResetGame();
        }
        else
        {
            print("GameSession is null");
        }
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadWin()
    {
        StartCoroutine(winWaitAndLoad());
    }

    public void QuitGame()
    {
        print("Quit");
        //works only in EXE programs
        Application.Quit();
    }
}


