using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject aiOptionsPanel;

    [Header("Buttons")]
    public Button vsHumanButton;
    public Button vsAIButton;
    public Button player1Button;
    public Button player2Button;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    [Header("Button Colors")]
    public Color selectedColor = Color.green;
    public Color defaultColor = Color.white;

    private string gameMode = "VS Human";
    private string playerSide = "Left";
    private string difficulty = "Medium";

    void Start()
    {
        aiOptionsPanel.SetActive(false);

        HighLightButton(vsHumanButton);
        HighLightButton(player1Button);
        HighLightButton(mediumButton);
    }

    public void SelectVSHuman()
    {
        gameMode = "VS Human";
        aiOptionsPanel.SetActive(false);
        HighLightButton(vsHumanButton);
        ResetButtonColor(vsAIButton);
    }

    public void SelectVSAI()
    {
        gameMode = "VS AI";
        aiOptionsPanel.SetActive(true);
        HighLightButton(vsAIButton);
        ResetButtonColor(vsHumanButton);
    }

    public void SelectPlayer1()
    {
        playerSide = "Left";
        HighLightButton(player1Button);
        ResetButtonColor(player2Button);
    }

    public void SelectPlayer2()
    {
        playerSide = "Right";
        HighLightButton(player2Button);
        ResetButtonColor(player1Button);
    }

    public void SelectEasy()
    {
        difficulty = "Easy";
        HighLightButton(easyButton);
        ResetButtonColor(mediumButton);
        ResetButtonColor(hardButton);
    }

    public void SelectMedium()
    {
        difficulty = "Medium";
        HighLightButton(mediumButton);
        ResetButtonColor(easyButton);
        ResetButtonColor(hardButton);
    }

    public void SelectHard()
    {
        difficulty = "Hard";
        HighLightButton(hardButton);
        ResetButtonColor(easyButton);
        ResetButtonColor(mediumButton);
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("GameMode", gameMode);
        PlayerPrefs.SetString("PlayerSide", playerSide);
        PlayerPrefs.SetString("Difficulty", difficulty);
        SceneManager.LoadScene("GameScene");
    }

    void HighLightButton(Button button)
    {
        button.GetComponent<Image>().color = selectedColor;
    }

    void ResetButtonColor(Button button)
    {
        button.GetComponent<Image>().color = defaultColor;
    }
}
