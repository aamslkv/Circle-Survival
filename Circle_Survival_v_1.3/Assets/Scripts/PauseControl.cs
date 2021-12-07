using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    [SerializeField] private GameObject Pause_panel;

    public GameObject gameOverPanel;

    private PlayerControl _playerScript;

    public VideoAds videoAds;

    private void Start()
    {
        _playerScript = FindObjectOfType<PlayerControl>();
    }

    private void Update()
    {
        if (_playerScript.game_over == true)
        {
            if (_playerScript != null)
            {
                Destroy(_playerScript.gameObject);
                Invoke("GameOver", 1.0f);
            }
            else if (_playerScript == null)
            {
                return;
            }
        }
    }

    public void PauseBttn()
    {
        Pause_panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayBttn()
    {
        Pause_panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void HomeBttn()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void ReturnBttn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    private void GameOver()
    {
        videoAds.ShowAd();
        print("game over");
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
