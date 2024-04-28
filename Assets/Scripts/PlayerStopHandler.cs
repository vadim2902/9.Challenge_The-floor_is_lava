using System;
using UnityEngine;

public class PlayerDestroyHandler : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private BallController _ballController;
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Finish"))
        {
            _ballController.enabled = false;
        }
    }
}