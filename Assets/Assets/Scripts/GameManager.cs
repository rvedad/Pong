using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public int player1Score = 0;
    public int player2Score = 0;
    public int winningScore = 5;
    void Awake()
    {
        instance = this;
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

        if (CheckWin())
        {
           string winner = player1Score >= winningScore ? "Player 1" : "Player 2";
           Debug.Log(winner + " wins!");
        }
        else
        {
            FindObjectOfType<BallController>().ResetBall();
        }
    }
    
    public bool CheckWin()
    {
        return player1Score >= winningScore || player2Score >= winningScore;
    }
}
