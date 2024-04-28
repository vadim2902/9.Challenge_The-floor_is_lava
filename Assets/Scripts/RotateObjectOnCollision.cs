using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateObjectOnCollision : MonoBehaviour
{
    public GameObject ObjectToRotate; 
    public float RotationSpeed = 30f;
    public TextMeshProUGUI TaskText;
    public TextMeshProUGUI TaskText2;
    private bool _isPlayerTouching; 
    
    private void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        if (_isPlayerTouching)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 120f, 0f);
            ObjectToRotate.transform.rotation = Quaternion.RotateTowards(ObjectToRotate.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            TaskText.color = Color.green;
            TaskText2.color = Color.green;
        }
        if (!_isPlayerTouching)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
            ObjectToRotate.transform.rotation = Quaternion.RotateTowards(ObjectToRotate.transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
            TaskText.color = Color.red;
            TaskText2.color = Color.red;
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Cup"))
        {
            _isPlayerTouching = true;
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Cup"))
        {
            _isPlayerTouching = false;
        }
    }
}