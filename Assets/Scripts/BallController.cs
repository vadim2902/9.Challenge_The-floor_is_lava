using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed = 7f;
    public float MaxSpeed = 5f;
    public float JumpForce = 3f;
    public float SpeedMult = 2f;
    public GameObject LosePanel;
    public GameObject WinPanel;
    private Rigidbody _rb;
    private bool _isTouchingLava, _isFinished, _isGrounded;

    void Start()
    {
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
        _isTouchingLava = false;
        _isFinished = false;
        _rb = GetComponent<Rigidbody>();
        _isGrounded = true;
    }

    void Update()
    {
        if (!_isTouchingLava && !_isFinished)
        {
            Vector3 cameraForward = Camera.main.transform.forward;
            cameraForward.y = 0f;
            cameraForward.Normalize();

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = (cameraForward * verticalInput + Camera.main.transform.right * horizontalInput).normalized;

            _rb.AddForce(movement * Speed * SpeedMult * Time.deltaTime);

            // Speed limit
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, MaxSpeed);
        }

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        _isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            _isTouchingLava = true;
        }
        if (other.CompareTag("Finish"))
        {
            _rb.velocity = Vector3.zero;
            _isTouchingLava = true;
        }
    }
}
