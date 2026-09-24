using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public PaddleController leftPaddle;
    public PaddleController rightPaddle;
    public AIController leftAI;
    public AIController rightAI;

    void Start()
    {
        string gameMode = PlayerPrefs.GetString("GameMode", "VS Human");
        string playerSide = PlayerPrefs.GetString("PlayerSide", "Left");

        if (gameMode == "VS Human")
        {
            leftPaddle.enabled = true;
            rightPaddle.enabled = true;
            leftAI.enabled = false;
            rightAI.enabled = false;
        }
        else
        {
            if (playerSide == "Left")
            {
                leftPaddle.enabled = true;
                rightPaddle.enabled = false;
                leftAI.enabled = false;
                rightAI.enabled = true;
                rightAI.ActivateAI();
            }
            else
            {
                leftPaddle.enabled = false;
                rightPaddle.enabled = true;
                leftAI.enabled = true;
                rightAI.enabled = false;
                leftAI.ActivateAI();
            }
        }
    }
}
