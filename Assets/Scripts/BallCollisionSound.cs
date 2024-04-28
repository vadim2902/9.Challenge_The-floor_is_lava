using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallCollisionSound : MonoBehaviour
{
    [SerializeField] 
    private AudioClip _collisionSound;
    private AudioSource _audioSource;
    
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Lava") && !collision.gameObject.CompareTag("Finish"))
        {
            _audioSource.PlayOneShot(_collisionSound ?? _audioSource.clip);
        }
    }
}
