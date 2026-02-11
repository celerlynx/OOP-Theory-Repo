using UnityEngine;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isGameActive = true;
    public bool isWin = false;
    private string _playerType;

    private List<string> _plrTypes = new List<string> { 
        BalloonPlayer.PLAYER_TYPE, 
        BallPlayer.PLAYER_TYPE 
    };

    //ENCAPSULATION
    public string playerType
    {
        get { return _playerType; } // getter returns backing field
        set
        {
            if (_playerType != value || string.IsNullOrEmpty(_playerType))
            {
                _playerType = _plrTypes.Contains(value)? value : _plrTypes[0];
            }

        } 
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string GetPlayerRules()
    {
        switch (_playerType)
        {
            case BalloonPlayer.PLAYER_TYPE:
                return "The Balloon can move up and down by pressing the arrow keys on the keyboard. It must not touch the red obstacles.";
            case BallPlayer.PLAYER_TYPE:
                return "The Ball can move left and right by pressing the arrow keys on the keyboard, and jump by pressing the space bar. It must not touch the red obstacles.";
            default:
                return "";
        }
    }

    //ABSTRACTION
    public void GameOver()
    {
        isGameActive = false;
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
            canvas.GetComponent<MenuUI>().ShowGameOver();
    }

}
