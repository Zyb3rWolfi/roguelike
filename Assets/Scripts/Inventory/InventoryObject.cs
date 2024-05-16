using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;
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
    
    public void SetItem(ItemScriptable item, ItemScriptable old_item)
    {
        Debug.Log("old item:" + old_item + " new item: " + item);
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log(items[i]);
            if (old_item == items[i])
            {
                Debug.Log("found the item");
                items[i] = item;
            }
        }
        
    }
    
    public void EquipWeapon(WeaponScriptable weapon)
    {
        currentWeapon = weapon;
    }
}
