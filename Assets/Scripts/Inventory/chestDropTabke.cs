using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Inventory
{
    [CreateAssetMenu(fileName = "chest", menuName = "DropTable/Create Chest", order = 0)]
    public class chestDropTabke : ScriptableObject
    {
        public string name;
        public List<ItemScriptable> dropTables;
    }
}