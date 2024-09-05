using UnityEngine;

public class InLight : MonoBehaviour
{
    private Player _player;
    private SaveZoneEvent _saveZoneEvent;
    
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _saveZoneEvent = GetComponent<SaveZoneEvent>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && _saveZoneEvent.isActiveSaveZone)
        {
            _player.playerOnLight = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && _saveZoneEvent.isActiveSaveZone)
        {
            _player.playerOnLight = false;
        }
    }
}