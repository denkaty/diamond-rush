using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int timeRemaining;
    private bool isGameOver = false;
    private bool isTimerActive = true;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;

    void Start()
    {
        timeRemaining = 30;
        gameOverText.enabled = false;
        StartCoroutine(TimerCountdown());
    }

    void Update()
    {
        if (isGameOver) return;

        if (isTimerActive)
        {
            timerText.text = $"Time Left: {timeRemaining}";

            if (timeRemaining <= 0)
            {
                GameOver();
            }
        }
    }

    private IEnumerator TimerCountdown()
    {
        while (timeRemaining > 0 && isTimerActive)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOverText.enabled = true;
        StartCoroutine(ResetGame());
    }

    private IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void FreezeTimer()
    {
        isTimerActive = false;
    }
}
