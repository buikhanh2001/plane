using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject PauesButton;
    public GameObject GameOverPanel;
    public GameObject levelCompletePanel;
    public GameObject EndText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        EndText.SetActive(false);
        levelCompletePanel.SetActive(false);
        pauseMenu.SetActive(false);
        PauesButton.SetActive(true);
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        PauesButton.SetActive(false);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        PauesButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        PauesButton.SetActive(false);
    }
    public IEnumerator LevelComplete()
    {
        yield return new WaitForSeconds(2f);
        EndText.SetActive(true);
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0f;
        levelCompletePanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
