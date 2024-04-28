using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    public float MouseSensitivity = 2f;
    public float DistanceFromPlayer = 5f;
    public Vector2 PitchMinMax = new Vector2(-40, 85);

    private float _yaw; 
    private float _pitch; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        _yaw += Input.GetAxis("Mouse X") * MouseSensitivity;
        _pitch -= Input.GetAxis("Mouse Y") * MouseSensitivity;
        _pitch = Mathf.Clamp(_pitch, PitchMinMax.x, PitchMinMax.y);

        transform.eulerAngles = new Vector3(_pitch, _yaw, 0);

        transform.position = Player.position - transform.forward * DistanceFromPlayer;
    }
}