using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BottomMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject pauseCurrent;
    public void OnClickMenuSelect()
    {
        SceneManager.LoadScene(5);
    }
    public void OnClickPauseMenu() 
    {
        pauseCurrent = Instantiate(pauseMenu);
        pauseCurrent.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnClickPlayMenu()
    {
        Time.timeScale = 1;
        Destroy(pauseMenu);
    }
    public void OnClickReturnMenu() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(6);
    }
}
