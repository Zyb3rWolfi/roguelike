using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class InventoryController : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _weaponButton;
    [SerializeField] private Button _potionButton;
    [SerializeField] private Button _relicButton;
    [SerializeField] private Button _armourButton;
    [Header("Inventory")]
    [SerializeField] private InventoryObject _inventoryObject;
    [SerializeField] private GameObject _itemSlot;
    [SerializeField] private GameObject _slotParent;

    [SerializeField] private ItemScriptable _tempItem;
    // Start is called before the first frame update
    void Start()
    {
        SetUpWeaponButton();
        SetUpPotionButton();
        SetUpRelicButton();
        SetUpArmourButton();
        SetUpInventory();
    }

    private void OnEnable()
    {
        WeaponAnimations.pickupItem += UpdateInventory;
        InvButton.OnItemClicked += ItemButtonPressed;
    }
    
    private void OnDisable()
    {
        WeaponAnimations.pickupItem -= UpdateInventory;
        InvButton.OnItemClicked -= ItemButtonPressed;
    }

    private void UpdateInventory(ItemScriptable _item)
    {
        _inventoryObject.AddItem(_item);
        SetUpInventory();
    }

    private void SetUpInventory()
    {
        /*foreach (Transform child in _slotParent.transform)
        {
            Destroy(child.gameObject);
        }*/
        int i = 0;
        int itemsAmount = _inventoryObject.items.Count;
        print("inv length: " + itemsAmount);
        foreach (Transform child in _slotParent.transform)
        {
            if (i >= itemsAmount)
            {
                return;
            }
            UnityEngine.UI.Image renderer = child.GetComponent<UnityEngine.UI.Image>();
            renderer.sprite = _inventoryObject.items[i].prefab.gameObject.GetComponent<SpriteRenderer>().sprite;
            print(i);
            print(renderer);
            i++;
        }
    }
    
    private void SetUpWeaponButton()
    {
        if (_inventoryObject.currentWeapon == null)
        {
            return;
        }
        UnityEngine.UI.Image img = _weaponButton.GetComponent<UnityEngine.UI.Image>();
        img.sprite = _inventoryObject.currentWeapon.prefab.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    
    private void SetUpPotionButton()
    {
        TextMeshProUGUI buttonText = _potionButton.GetComponentInChildren<TextMeshProUGUI>();
        if (_inventoryObject.currentPotion != null)
        {
            Image img = _potionButton.GetComponent<Image>();
            img.sprite = _inventoryObject.currentPotion.prefab.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            buttonText.text = "Empty";
        }
    }
    
    private void SetUpRelicButton()
    {
        TextMeshProUGUI buttonText = _relicButton.GetComponentInChildren<TextMeshProUGUI>();
        if (_inventoryObject.currentRelic != null)
        {
            Image img = _relicButton.GetComponent<Image>();
            img.sprite = _inventoryObject.currentRelic.prefab.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            buttonText.text = "Empty";
        }
    }
    
    private void SetUpArmourButton()
    {
        TextMeshProUGUI buttonText = _armourButton.GetComponentInChildren<TextMeshProUGUI>();
        if (_inventoryObject.currentArmour != null)
        {
            Image img = _armourButton.GetComponent<Image>();
            img.sprite = _inventoryObject.currentArmour.prefab.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            buttonText.text = "Empty";
            
        }
    }

    public void ItemButtonPressed(ItemScriptable item)
    {
        _tempItem = item;
    }

    public void WeaponButtonPress()
    {
        if (_tempItem is WeaponScriptable && _inventoryObject.currentWeapon != null)
        {
            ItemScriptable _currentWeapon = _inventoryObject.currentWeapon; // weapon to inv
            _inventoryObject.currentWeapon = _tempItem as WeaponScriptable; // Inv to weapon
            _inventoryObject.SetItem(_currentWeapon, _tempItem);
            SetUpInventory();
            SetUpWeaponButton();
        } else if (_inventoryObject.currentWeapon == null)
        {
            _inventoryObject.currentWeapon = _tempItem as WeaponScriptable; // Inv to weapon
            _inventoryObject.RemoveItem(_tempItem);
            SetUpInventory();
            SetUpWeaponButton();
        }
    }

    public void ArmourButtonPress()
    {
        if (_tempItem is armourScritpable && _inventoryObject.currentArmour != null)
        {
            ItemScriptable _currentArmour = _inventoryObject.currentArmour;
            _inventoryObject.currentArmour = _tempItem as armourScritpable;
            _inventoryObject.SetItem(_currentArmour, _tempItem);
            SetUpInventory();
            SetUpArmourButton();
            
        } else if (_inventoryObject.currentArmour == null)
        {
            _inventoryObject.currentArmour = _tempItem as armourScritpable; // Inv to weapon
            _inventoryObject.RemoveItem(_tempItem);
            SetUpInventory();
            SetUpWeaponButton();
        }

    }
    
    public void RelicButtonPress()
    {
        if (_tempItem is RelicScriptable && _inventoryObject.currentRelic != null)
        {
            ItemScriptable _currentRellic = _inventoryObject.currentRelic;
            _inventoryObject.currentRelic = _tempItem as RelicScriptable;
            _inventoryObject.SetItem( _currentRellic, _tempItem);
            SetUpInventory();
            SetUpArmourButton();
            
        } else if (_inventoryObject.currentRelic == null)
        {
            _inventoryObject.currentRelic = _tempItem as RelicScriptable; // Inv to weapon
            _inventoryObject.RemoveItem(_tempItem);
            SetUpInventory();
            SetUpWeaponButton();
        }

    }
    
    public void PotionButtonPress()
    {
        if (_tempItem is PotionScriptable && _inventoryObject.currentPotion != null)
        {
            ItemScriptable _currentPotion = _inventoryObject.currentPotion;
            _inventoryObject.currentPotion = _tempItem as PotionScriptable;
            _inventoryObject.SetItem(_currentPotion, _tempItem);
            SetUpInventory();
            SetUpArmourButton();
            
        } else if (_inventoryObject.currentPotion == null)
        {
            _inventoryObject.currentPotion = _tempItem as PotionScriptable; // Inv to weapon
            _inventoryObject.RemoveItem(_tempItem);
            SetUpInventory();
            SetUpWeaponButton();
        }

    }

}
