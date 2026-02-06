using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string playerType;
    public TextMeshProUGUI playerRulesText;

    private Button _menuButton;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        UpdatePlayerTypeInfo();
    }

    /**
     * Set default Player type and update Player rules text
     */
    private void UpdatePlayerTypeInfo()
    {
        if (string.IsNullOrEmpty(playerType))
        {
            playerType = BalloonPlayer.PLAYER_TYPE;
        }
        if (playerRulesText != null)
            playerRulesText.text = GetPlayerRules();
    }

    //Change Player type radio button value
    public void SelectPlayer(Toggle toggle)
    {
        if (toggle != null && toggle.isOn)
        {
            playerType = toggle.name;
            UpdatePlayerTypeInfo();
        }
        
    }

    public string GetPlayerRules()
    {
        switch (playerType)
        {
            case BalloonPlayer.PLAYER_TYPE:
                return "The Balloon can move by pressing the arrow keys on the keyboard. It must fly around obstacles without touching them.";
            case BallPlayer.PLAYER_TYPE:
                return "The Ball can move left and right by pressing the arrow keys on the keyboard, and jump by pressing the space bar. It should not fall from a height of more than one cube.";
            default:
                return "";
        }
    }

    //Start button click
    public void StartNew()
    {
       
        //Instance.SetCurrentPlayer();
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

    public void InitMenuButton()
    {
        if (_menuButton == null)
        {
            GameObject buttonObj = GameObject.Find("Menu_Button");
            if (buttonObj != null)
            {
                Debug.Log("Menu button");
                _menuButton = buttonObj.GetComponent<Button>();
                _menuButton.onClick.AddListener(BackToMenu);
            }
        }
    }

    void OnDestroy()
    {
        if (_menuButton != null)
        {
            _menuButton.onClick.RemoveListener(BackToMenu);
            _menuButton = null;
            Debug.Log("Menu button remove");
        }
    }

}
