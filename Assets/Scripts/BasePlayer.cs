using UnityEngine;


public abstract class BasePlayer : MonoBehaviour
{
    private float _speed = 2f;
    private Vector3 _curPos;
    private float _bound = 17f;
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
        if (collision.gameObject.CompareTag("Deadly"))
        {
            Destroy(gameObject);
            GameManager.Instance.GameOver();
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameActive)
        {
            Move();

            //Prevent moving out of bounds
            _curPos = transform.position;

            if (Mathf.Abs(_curPos.x) > _bound)
            {
                _curPos.x = Mathf.Sign(_curPos.x) * _bound;
                transform.position = _curPos;
            }
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GameManager.Instance.isWin = true;
            GameManager.Instance.GameOver();
        }
    }

}
