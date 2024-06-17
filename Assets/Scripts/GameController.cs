using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TMP_Text playerScoreText;
    public GameObject gameOverPanel;
    public TMP_Text winnerPlayer;
    public AudioSource audioSource;
    public AudioClip gameOverSound;
    public int maxPoints;
    private int _playerOneScore = 0;
    private int _playerTwoScore = 0;

    void Start()
    {
        playerScoreText.text = _playerOneScore + "  |  " + _playerTwoScore;
    }

    public void AddScore(bool isPlayerOne)
    {
        if(isPlayerOne)
        {   
            _playerOneScore += 1;
        }
        else
        {
            _playerTwoScore += 1;
        }
        playerScoreText.text = _playerOneScore + "  |  " + _playerTwoScore;

        if(_playerOneScore >= maxPoints)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            winnerPlayer.text = "Player\n1\nWins!";
            audioSource.PlayOneShot(gameOverSound);
        }
        else if(_playerTwoScore >= maxPoints)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            winnerPlayer.text = "Player\n2\nWins!";
            audioSource.PlayOneShot(gameOverSound);
        }
    }

    public void RestartTime()
    {
        Time.timeScale = 1;
    }
}
