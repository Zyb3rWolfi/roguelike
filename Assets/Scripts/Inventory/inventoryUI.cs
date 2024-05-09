using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class inventoryUI : MonoBehaviour
{
    public TextMeshProUGUI itemName;

    public TextMeshProUGUI descriptionText;

    public Image iconImage;

    public TextMeshProUGUI quantityText;
    private WeaponScriptable _item;
    private GameObject _prefabPreview;
    public static event Action<WeaponScriptable, GameObject> itemEquipped;

    public void UpdateSlot(WeaponScriptable item)
    {
        itemName.text = item.name;
        _item = item;
    }
    
    public void slotPressed()
    {
        itemEquipped?.Invoke(_item, _prefabPreview);
    } 
}
