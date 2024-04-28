using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip _gameOverSound;
    [SerializeField]
    private AudioSource _audioSource;
    
    private bool isSoundPlayed = false;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayGameOverSound(collision.gameObject.CompareTag("Lava") ? _gameOverSound : null);
    }

    private void PlayGameOverSound(AudioClip sound)
    {
        if (!isSoundPlayed)
        {
            _audioSource.PlayOneShot(sound);
            isSoundPlayed = true;
        }
    }
}
