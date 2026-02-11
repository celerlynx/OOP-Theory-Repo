using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject[] flyingObstacles;
    private float _speed = 2f;
    private float _height = 6f;
    private float _startY = 3f;
    private float _newY;

    // Update is called once per frame
    void Update()
    {
        // Calculate the new Y position using PingPong for smooth oscillation
        _newY = Mathf.PingPong(Time.time * _speed, _height) + _startY;
        foreach (var item in flyingObstacles)
        {
            // Set the object's new position, maintaining its original X and Z
            item.transform.position = new Vector3(item.transform.position.x, _newY, item.transform.position.z);
        }
        
    }
}
