using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Inventory
{
    [CreateAssetMenu(fileName = "droptable", menuName = "DropTable/Create", order = 0)]
    public class DropTableScriptable : ScriptableObject
    {
        public string name;
        public List<ItemScriptable> items;
        public List<int> dropChance;
    }
}