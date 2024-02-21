using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject panel;
    public GameObject LoseGameText;
    public GameObject mainMenuButton;
    public GameObject retryButton;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        mainMenuButton.SetActive(false);
        retryButton.SetActive(false);
    }

    public void PlayerDied()
    {
        panel.SetActive(true);
        LoseGameText.SetActive(true);
        mainMenuButton.SetActive(true);
        retryButton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reset()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
