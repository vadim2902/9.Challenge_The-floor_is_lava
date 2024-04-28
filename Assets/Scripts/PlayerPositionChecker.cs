using UnityEngine;

public class PlayerPositionChecker : MonoBehaviour
{
    public Vector3 NewPosition = new Vector3(4.25f, 1.46f, -1.94f);

    void Update()
    {
        if (transform.position.y < -10f)
        {
            transform.position = NewPosition;
        }
    }
}