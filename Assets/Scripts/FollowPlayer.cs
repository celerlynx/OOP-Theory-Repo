using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _offset = new Vector3(6, 0, -9);
    private Vector3 _curPos;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        //the camera Y position depends on the player type (balloon or ball)
        //offset.y = (player.transform.position.y > 1f) ? -4f : 4.25f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_player != null)
        {
            _curPos = _player.transform.position + _offset;
            _curPos.y = transform.position.y;
            transform.position = _curPos;
        }
    }
}
