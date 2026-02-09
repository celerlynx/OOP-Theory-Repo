using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _offset = new Vector3(6, 0, -9);
    private Vector3 _curPos;
    private float _leftBound = -14;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_player != null && _player.transform.position.x > _leftBound)
        {
            _curPos = _player.transform.position + _offset;
            _curPos.y = transform.position.y;
            transform.position = _curPos;
        }
    }
}
