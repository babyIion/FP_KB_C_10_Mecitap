using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject PopUpPause;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1f;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1f;
    }

    public void Level()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        PopUpPause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    public void Pause()
    {
        PopUpPause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }
}
