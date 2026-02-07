using UnityEngine;

public class BalloonPlayer : BasePlayer
{
    private float _verticalInput;
    public const string PLAYER_TYPE = "Balloon";


    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.playerType == PLAYER_TYPE)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);

        }
    }

    public override void Move()
    {
        // get the user's vertical input
        _verticalInput = Input.GetAxis("Vertical");
        // move the balloon forward at a constant rate
        transform.Translate(speed * Time.deltaTime * Vector3.right);
        // move the balloon up/down based on up/down arrow keys
        transform.Translate(speed * Time.deltaTime * _verticalInput * Vector3.up);
    }

    public override void OnCollisionEnter(Collision collision)
    {
       
    }

    public override string GetName()
    {
        return PLAYER_TYPE;
    }

}
