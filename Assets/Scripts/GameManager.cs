using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score")]
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public int player1Score = 0;
    public int player2Score = 0;
    public int winningScore = 5;

    [Header("Win Screen")]
    public GameObject winPanel;
    public TextMeshProUGUI winText;

    [Header("Audio")]
    public AudioClip scoreSound;
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        winPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void AddScore(int player)
    {
        if (player == 1)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
            FlashScoreText(1);
        }
        else if (player == 2)
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
            FlashScoreText(2);
        }

        if (player1Score >= winningScore || player2Score >= winningScore)
        {
            WinGame();
        }
        else
        {
           FindAnyObjectByType<BallController>().ResetBall();
        }
    }

    void WinGame()
    {
        FindAnyObjectByType<BallController>().StopBall();
        string winner = player1Score >= winningScore ? "Player 1" : "Player 2";
        winText.text = winner + " wins!";
        winPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu()
    {
       SceneManager.LoadScene(0);
    }

    public void PlayScoreSound()
    {
        audioSource.PlayOneShot(scoreSound);
    }

    public void FlashScoreText(int player)
    {
        if (player == 1)
        {
            StartCoroutine(FlashScoreRoutine(player1ScoreText));
        }
        else if (player == 2)
        {
            StartCoroutine(FlashScoreRoutine(player2ScoreText));
        }
    }

    IEnumerator FlashScoreRoutine(TextMeshProUGUI scoreText)
    {
        for (int i = 0; i < 3; i++)
        {
            Color originalColor = scoreText.color;
            scoreText.color = Color.yellow;
            yield return new WaitForSeconds(0.2f);
            scoreText.color = originalColor;
            yield return new WaitForSeconds(0.2f);
        }
    }
}

