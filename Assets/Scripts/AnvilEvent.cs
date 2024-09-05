using UnityEngine;

public class AnvilEvent : MonoBehaviour
{
    private bool _isOnTrigger;

    private AudioSource _sound;
    
    private Inventory _inventory;
    private UI _ui;
    private SetDialogText _setDialogText;
    
    void Awake()
    {
        _sound = GetComponent<AudioSource>();
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
        _setDialogText = GameObject.FindGameObjectWithTag("Dialog Text").GetComponent<SetDialogText>();
    }
    
    void Update()
    {
        if (
            Input.GetKeyUp(KeyCode.E) && 
            _isOnTrigger && 
            !_sound.isPlaying &&
            _inventory.inventory.Contains(Inventory.InventoryItemTypes.Nails) &&
            _inventory.isHammerContains &&
            _ui.nailsFixedScoreCount != UI.NailsFixedScoreCountMax
            )
        {
            _sound.Play();
            _inventory.RemoveToInventorySlot(Inventory.InventoryItemTypes.Nails);
            _inventory.SetToInventorySlot(Inventory.InventoryItemTypes.NailsFixed);
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