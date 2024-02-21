using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public GameObject panel;
    public GameObject mainMenuButton;
    public GameObject endGameText;

    private void Start()
    {
        panel.SetActive(false);
        mainMenuButton.SetActive(false);
        endGameText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        panel.SetActive(true);
        mainMenuButton.SetActive(true);
        endGameText.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
