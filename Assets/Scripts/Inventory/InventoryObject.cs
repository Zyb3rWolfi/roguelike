using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/Inventory")]
public class InventoryObject : ScriptableObject
{
    public WeaponScriptable currentWeapon;
    public List<WeaponScriptable> items = new List<WeaponScriptable>();

    public void AddItem(WeaponScriptable item)
    {
        items.Add(item);
    }

    public void RemoveItem(WeaponScriptable item)
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