using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        SetUpWeaponButton();
        SetUpPotionButton();
        SetUpRelicButton();
        SetUpArmourButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetUpWeaponButton()
    {
        TextMeshProUGUI buttonText = _weaponButton.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = _inventoryObject.currentWeapon.name;
    }
    
    private void SetUpPotionButton()
    {
        TextMeshProUGUI buttonText = _potionButton.GetComponentInChildren<TextMeshProUGUI>();
        if (_inventoryObject.currentPotion != null)
        {
            buttonText.text = _inventoryObject.currentPotion.name;
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
            buttonText.text = _inventoryObject.currentRelic.name;
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
            buttonText.text = _inventoryObject.currentArmour.name;
        }
        else
        {
            buttonText.text = "Empty";
        }
    }
}
