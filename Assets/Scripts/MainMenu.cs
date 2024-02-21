using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Credit()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
}
