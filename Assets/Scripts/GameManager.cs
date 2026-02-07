using UnityEngine;
using System.Collections.Generic;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string _playerType;

    private List<string> _plrTypes = new List<string> { 
        BalloonPlayer.PLAYER_TYPE, 
        BallPlayer.PLAYER_TYPE 
    };
    public string playerType
    {
        get { return _playerType; } // getter returns backing field
        set
        {
            if (_plrTypes.Contains(value))
                _playerType = value;
            else
                _playerType = BalloonPlayer.PLAYER_TYPE;

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
                return "The Balloon can move by pressing the arrow keys on the keyboard. It must fly around obstacles without touching them.";
            case BallPlayer.PLAYER_TYPE:
                return "The Ball can move left and right by pressing the arrow keys on the keyboard, and jump by pressing the space bar. It should not fall from a height of more than one cube.";
            default:
                return "";
        }
    }

}
