using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Inventory;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [Header("Drop Table")]
    [SerializeField] chestDropTabke _chestDropTable;
    [Header("Debugging")]
    [SerializeField] private bool _isOpened = false;

    private void OnMouseDown()
    {
        if (_isOpened)
        {
            return;
        }
        ItemScriptable item = GetRandomItems();
        Instantiate(item.prefab, transform.position, Quaternion.identity);
        _isOpened = true;
    }

    private ItemScriptable GetRandomItems()
    {
        int randomIndex = UnityEngine.Random.Range(0, _chestDropTable.dropTables.Count);
        return _chestDropTable.dropTables[randomIndex];
    }
}
