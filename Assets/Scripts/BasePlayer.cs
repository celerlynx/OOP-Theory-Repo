using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public abstract class BasePlayer : MonoBehaviour
{
    private float _speed = 2f;
    public float speed
    {
        get { return _speed; } // getter returns backing field
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative player speed!");
            }
            else
            {
                _speed = value;
            }
        } // setter uses backing field
    }

    public virtual void Move()
    { 
    }


    // Use OnCollisionEnter to detect when the character hits the ground
    public virtual void OnCollisionEnter(Collision collision)
    {

    }

    public virtual string GetName()
    {
        return "Player";
    }


    public virtual string GetRules()
    {
        return "Rules";
    }

    void Update()
    {
        Move();
    }

}
