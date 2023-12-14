using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public int score;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;

    [SerializeField] private TextMeshProUGUI _lastScoreText;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject GameOverPanel;

    private bool isPaused = false;

    [SerializeField] private float timer = 60;


    private void Start() {
        Time.timeScale = 1f;
        _scoreText.SetText("Score: " + score.ToString());
    }

    private void Update() {
        timer -= Time.deltaTime;
        _timerText.SetText("Timer: " + timer.ToString());

        if(timer <= 0) {
            _lastScoreText.SetText("Score: " + score.ToString());
            GameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    public void AddScore(int value) {
        score += value;
        _scoreText.SetText("Score: " + score.ToString());
    }

    public void Retry() {
        SceneManager.LoadScene("Gameplay");
    }
    public void GoToMenu() {
        SceneManager.LoadScene("MainMenu");
    }


}
