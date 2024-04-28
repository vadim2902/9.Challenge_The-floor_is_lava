using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject objectToShow;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (objectToShow != null)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                objectToShow.SetActive(true);
            }
        }
    }
}