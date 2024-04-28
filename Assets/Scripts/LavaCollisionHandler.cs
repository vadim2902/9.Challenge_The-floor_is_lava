using UnityEngine;
using UnityEngine.Serialization;

public class LavaCollisionHandler : MonoBehaviour
{
    public ParticleSystem LavaParticles;
    public GameObject Player;
    public GameObject LoseCanvas;
    public GameObject GameUI;

    private bool _hasPlayed; 
    private bool _playerEntered;  
    private AudioSource _audioSource;  
    
    void Start()
    {
        LavaParticles.Stop();
        _audioSource = GetComponent<AudioSource>();
        _hasPlayed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_hasPlayed)
        {
            _playerEntered = true;
        }
    }

    private void Update()
    {
        if (_playerEntered && !_hasPlayed)
        {
            if (LavaParticles != null)
            {
                Instantiate(LavaParticles, Player.transform.position, Quaternion.identity);
                _audioSource.PlayOneShot(_audioSource.clip);
            }

            _hasPlayed = true;

            //Destroy(LavaParticles.gameObject, LavaParticles.main.duration);
            Player.SetActive(false);
            GameUI.SetActive(false);
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            LoseCanvas.SetActive(true);
        }
    }
}