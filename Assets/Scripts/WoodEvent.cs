using UnityEngine;

public class WoodEvent : MonoBehaviour
{
    private bool _isOnTrigger ;

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
            _inventory.inventorySize < 2 &&
            _ui.woodScoreCount != UI.WoodScoreCountMax)
        {
            _sound.Play();
            _inventory.SetToInventorySlot(Inventory.InventoryItemTypes.Wood);
            _inventory.SetToInventorySlot(Inventory.InventoryItemTypes.Wood);
            _ui.woodScoreCount++;
            _ui.isChangedUI = true;
        }
        else if (
            Input.GetKeyUp(KeyCode.E) && 
            _isOnTrigger && 
            !_sound.isPlaying &&
            _ui.woodScoreCount == UI.WoodScoreCountMax)
        {
            _setDialogText.SetCustomText("Мені вже вистачає деревини.");
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