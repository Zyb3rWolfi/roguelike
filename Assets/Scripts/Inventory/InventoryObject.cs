using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    public WeaponScriptable currentWeapon;
    public PotionScriptable currentPotion;
    public RelicScriptable currentRelic;
    public armourScritpable currentArmour;
    public List<ItemScriptable> items = new List<ItemScriptable>();

    public void AddItem(ItemScriptable item)
    {
        items.Add(item);
    }

    public void RemoveItem(ItemScriptable item)
    {
        items.Remove(item);
    }

    public void ClearInventory()
    {
        items.Clear();
    }
    
    public void EquipWeapon(WeaponScriptable weapon)
    {
        currentWeapon = weapon;
    }
}
