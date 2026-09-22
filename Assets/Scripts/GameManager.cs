using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        winPanel.SetActive(false);
    }
    
    public void AddScore(int player)
    {
        if (player == 1)
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
        }
        else if (player == 2)
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
        }

        if (player1Score >= winningScore || player2Score >= winningScore)
        {
           WinGame();
        }
        else
        {
            FindObjectOfType<BallController>().ResetBall();
        }
    }
    
    void WinGame()
    {
        FindObjectOfType<BallController>().StopBall();
        string winner = player1Score >= winningScore ? "Player 1" : "Player 2";
        winText.text = winner + " wins!";
        winPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
