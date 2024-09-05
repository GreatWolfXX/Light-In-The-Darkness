using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public enum InventoryItemTypes
    {
        Wood,
        Planks,
        Apple,
        Nails,
        NailsFixed
    }

    [HideInInspector] public List<InventoryItemTypes> inventory;
    private List<GameObject> _inventorySlots;
    
    [HideInInspector] 
    public int inventorySizeMax = 3;
    [HideInInspector] 
    public int inventorySize;

    public Sprite woodImage;
    public Sprite planksImage;
    public Sprite appleImage;
    public Sprite nailsImage;
    public Sprite nailsFixedImage;
    public Sprite emptyImage;
    
    [HideInInspector] 
    public bool isAxeContains;
    [HideInInspector] 
    public bool isHammerContains;

    private SetDialogText _setDialogText;

    void Awake()
    {
        _inventorySlots = GameObject.FindGameObjectsWithTag("Inventory Slot").ToList();
        _setDialogText = GameObject.FindGameObjectWithTag("Dialog Text").GetComponent<SetDialogText>();
    }

    public void SetToInventorySlot(InventoryItemTypes item)
    {
        if(inventory.Count < inventorySizeMax)
        {
            inventory.Add(item);
            var index = 0;
            foreach (var itemInventory in inventory)
            {
                var image = _inventorySlots[index].GetComponent<Image>();
                switch (itemInventory)
                {
                    case InventoryItemTypes.Wood:
                    {
                        image.sprite = woodImage;
                        break;
                    }
                    case InventoryItemTypes.Planks:
                    {
                        image.sprite = planksImage;
                        break;
                    }
                    case InventoryItemTypes.Apple:
                    {
                        image.sprite = appleImage;
                        break;
                    }
                    case InventoryItemTypes.Nails:
                    {
                        image.sprite = nailsImage;
                        break;
                    }
                    case InventoryItemTypes.NailsFixed:
                    {
                        image.sprite = nailsFixedImage;
                        break;
                    }
                }
                index++;
            }
        }
        else
        {
            _setDialogText.SetCustomText("Інвентар заповнений.");
        }
        inventorySize = inventory.Count();
    }

    public void RemoveToInventorySlot(InventoryItemTypes item)
    {
        inventory.Remove(item);
    }

    public void ClearInventory()
    {
        inventory.Clear();
        foreach (var slot in _inventorySlots)
        {
            var image = slot.GetComponent<Image>();
            image.sprite = emptyImage;
        }
        inventorySize = 0;
    }
}