using UnityEngine;

public class HammerEven : MonoBehaviour
{
    private bool _isOnTrigger;

    private AudioSource _sound;
    
    private Inventory _inventory;
    private UI _ui;

    public GameObject hammer;
    public GameObject hint;
    
    void Awake()
    {
        _sound = GetComponent<AudioSource>();
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }
    
    void Update()
    {
        if (
            Input.GetKeyUp(KeyCode.E) && 
            _isOnTrigger && 
            !_sound.isPlaying &&
            _ui.hammerScoreCount != UI.HammerScoreCountMax
            )
        {
            _sound.Play();
            _inventory.isHammerContains = true;
            _ui.hammerScoreCount++;
            _ui.isChangedUI = true;
            Destroy(hammer);
            Destroy(hint);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isOnTrigger = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isOnTrigger = false;
        }
    }
}