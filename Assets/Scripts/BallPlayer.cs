using UnityEngine;

public class BallPlayer : BasePlayer
{
    private float _jumpForce = 7f;
    private float _horizontalInput;
    private Rigidbody _playerRb;
    private bool _isGrounded;

    public const string PLAYER_TYPE = "Ball";

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

    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    public override void Move()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = _horizontalInput * Time.deltaTime * speed * Vector3.right;
        _playerRb.MovePosition(_playerRb.position + movement);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            // Calculate the total force vector: combination of up direction and forward direction
            Vector3 totalJumpForce = Vector3.up * _jumpForce + movement;

            // Apply the force for an instant push
            _playerRb.AddForce(totalJumpForce, ForceMode.Impulse);
            _isGrounded = false;

        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        _isGrounded = true;
    }

}
