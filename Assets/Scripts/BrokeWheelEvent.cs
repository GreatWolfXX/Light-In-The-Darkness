using UnityEngine;
using UnityEngine.SceneManagement;

public class BrokeWheelEvent : MonoBehaviour
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
            _inventory.inventorySize != 0
        )
        {
            _sound.Play();
            foreach (var item in _inventory.inventory)
            {
                switch (item)
                {
                    case Inventory.InventoryItemTypes.Planks:
                    {
                        _ui.planksScoreCount++;
                        break;
                    }
                    case Inventory.InventoryItemTypes.Apple:
                    {
                        _ui.appleScoreCount++;
                        break;
                    }
                    case Inventory.InventoryItemTypes.NailsFixed:
                    {
                        _ui.nailsFixedScoreCount++;
                        break;
                    }
                }
                _ui.isChangedUI = true;
            }

            _inventory.ClearInventory();

            if (
                _ui.woodScoreCount == UI.WoodScoreCountMax &&
                _ui.planksScoreCount == UI.PlanksScoreCountMax &&
                _ui.appleScoreCount == UI.AppleScoreCountMax &&
                _ui.nailsScoreCount == UI.NailsScoreCountMax &&
                _ui.nailsFixedScoreCount == UI.NailsFixedScoreCountMax
                )
            {
                SceneManager.LoadScene(3);
            }
        }
        else if (Input.GetKeyUp(KeyCode.E) && 
                 _isOnTrigger && 
                 !_sound.isPlaying && 
                 _inventory.inventorySize == 0)
        {
            _setDialogText.SetCustomText("В мене нічого немає.");
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