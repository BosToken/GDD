using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{    
    public void PauseGame()
    {
        Time.timeScale = 0;        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;        
    }

    public void RetryGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
