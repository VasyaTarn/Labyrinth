using Enemy;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject resumeGameButton;
    [SerializeField] private GameObject backToMenuButton;

    private bool isGameStarted = false;

    private bool isGamePaused = false;

    private void Update()
    {
        pauseMenu();
    }

    public void play()
    {

        GameManager.Instance.setPlayButton(playButton);
        GameManager.Instance.setExitButton(exitButton);

        playButton.SetActive(false);
        exitButton.SetActive(false);

        GameManager.Instance.swapToGame();

        Cursor.lockState = CursorLockMode.Locked;

        StartCoroutine(DelayedStartGame());
    }

    public void exit()
    {
        Application.Quit();
    }

    public void resumeGame()
    {
        resumeGameButton.SetActive(false);
        backToMenuButton.SetActive(false);
        exitButton.SetActive(false);

        Time.timeScale = 1f;
        isGamePaused = !isGamePaused;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void backToMenu()
    {
        Time.timeScale = 1f;
        resumeGameButton.SetActive(false);
        backToMenuButton.SetActive(false);
        exitButton.SetActive(false);
        GameManager.Instance.finishGame();
    }

    private void pauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isGameStarted)
        {
            if(!isGamePaused)
            {
                Cursor.lockState = CursorLockMode.None;
                resumeGameButton.SetActive(true);
                backToMenuButton.SetActive(true);
                exitButton.SetActive(true);

                Time.timeScale = 0f;
                isGamePaused = !isGamePaused;
            }
            else
            {
                resumeGame();
            }
        }
    }

    private IEnumerator DelayedStartGame()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.startGame();
        isGameStarted = true;
    }
}
