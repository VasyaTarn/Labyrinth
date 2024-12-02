using Enemy;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject stamina;
    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private Transform startTransform;

    [Header("Cameras")]
    [SerializeField] private GameObject menuCamera;
    [SerializeField] private GameObject playerCamera;

    private GameObject playButton;
    private GameObject exitButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void startGame()
    {
        stamina.SetActive(true);
        spawner.spawnEnemy();
        playerMover.moveStatus = true;
    }

    public void finishGame()
    {
        stamina.SetActive(false);

        swapToMenu();

        Invoke(nameof(enableButtons), 2f);

        playerMover.moveStatus = false;

        Destroy(GameObject.FindWithTag("Enemy"));

    }

    private void enableButtons()
    {
        playButton.SetActive(true);
        exitButton.SetActive(true);

        playerMover.transform.position = startTransform.position;
        playerMover.transform.rotation = Quaternion.identity;
        Cursor.lockState = CursorLockMode.None;
    }

    public void swapToMenu()
    {
        playerCamera.SetActive(false);
        menuCamera.SetActive(true);
    }

    public void swapToGame()
    {
        menuCamera.SetActive(false);
        playerCamera.SetActive(true);
    }

    public void setPlayButton(GameObject btn)
    {
        playButton = btn;
    }

    public void setExitButton(GameObject btn)
    {
        exitButton = btn;
    }
}
