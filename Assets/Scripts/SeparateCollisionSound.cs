using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparateCollisionSound : MonoBehaviour
{
    public AudioClip Sound;
    private AudioSource _audioSource;
    
    private bool IsSoundPlayed = false;


    private void Start()
    {
        IsSoundPlayed = false;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayGameOverSound(collision.gameObject.CompareTag("Player") ? Sound : null);
    }

    private void PlayGameOverSound(AudioClip sound)
    {
        if (sound != null && !IsSoundPlayed)
        {
            _audioSource.PlayOneShot(sound);
            IsSoundPlayed = true;
        }
    }
    
}
