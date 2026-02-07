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

    private void Start()
    {
        if (GameManager.Instance != null)
            UpdatePlayerTypeInfo();
    }


    /**
    * Set default Player type and update Player rules text
    */
    private void UpdatePlayerTypeInfo()
    {
        if (string.IsNullOrEmpty(GameManager.Instance.playerType))
        {
            GameManager.Instance.playerType = BalloonPlayer.PLAYER_TYPE;
        }
        if (playerRulesText != null)
            playerRulesText.text = GameManager.Instance.GetPlayerRules();
    }

    //Change Player type radio button value
    public void SelectPlayer(Toggle toggle)
    {
        if (toggle != null && toggle.isOn && GameManager.Instance != null)
        {
            GameManager.Instance.playerType = toggle.name;
            UpdatePlayerTypeInfo();
        }

    }

    //Start button click
    public void StartNew()
    {
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

}
