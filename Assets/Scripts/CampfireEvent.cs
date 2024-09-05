using UnityEngine;

public class CampfireEvent : MonoBehaviour
{
    private bool _isOnTrigger;

    private AudioSource _sound;
    private TorchFire _torchFire;
    private Player _player;
    
    void Awake()
    {
        _sound = GetComponent<AudioSource>();
        _torchFire =  GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<TorchFire>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    
    void Update()
    {
        if (
            Input.GetKeyUp(KeyCode.E) && 
            _isOnTrigger && !_sound.isPlaying
        )
        {
            _sound.Play();
            _torchFire.ResetTorch();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isOnTrigger = true;
            _player.playerOnLight = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isOnTrigger = false;
            _player.playerOnLight = false;
        }
    }
}