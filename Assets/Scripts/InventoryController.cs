using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private Button _weaponButton;
    [SerializeField] private InventoryObject _inventoryObject;
    // Start is called before the first frame update
    void Start()
    {
        SetUpWeaponButton();
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
}
