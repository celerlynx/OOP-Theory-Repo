using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{

    public TextMeshProUGUI playerRulesText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;


    //ABSTRACTION
    /**
    * Set default Player type and update Player rules text on the Title screen only
    */
    private void UpdatePlayerTypeInfo(string pType)
    {
        if (playerRulesText != null && GameManager.Instance != null)
        {
            GameManager.Instance.playerType = pType;
            playerRulesText.text = GameManager.Instance.GetPlayerRules();
        }
    }

    private void Start()
    {
        UpdatePlayerTypeInfo(null);
    }
    
    //Change Player type radio button value
    public void SelectPlayer(Toggle toggle)
    {
        if (toggle != null && toggle.isOn)
        {
            UpdatePlayerTypeInfo(toggle.name);
        }

    }

    //Start/Restart button click
    public void StartNew()
    {
        GameManager.Instance.isGameActive = true;
        GameManager.Instance.isWin = false;
        SceneManager.LoadScene(1);
    }

    //Quit button click
    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    //Back to menu button click in the main scene
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowGameOver()
    {
        if (!GameManager.Instance.isGameActive && gameOverText != null)
        {
            gameOverText.text = (GameManager.Instance.isWin)? "YOU WON!" : "Game Over";
            gameOverText.gameObject.SetActive(true);
            if (restartButton != null)
                restartButton.gameObject.SetActive(true);
        }
    }

}
