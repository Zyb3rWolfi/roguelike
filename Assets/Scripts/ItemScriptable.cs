using UnityEngine;

namespace DefaultNamespace
{
    public class ItemScriptable : ScriptableObject
    {
        public string name;
        public string description;
        public GameObject prefab;
        public enum ItemType
        {
            Weapon,
            Consumable,
            Armour,
            Relic
        }

    }
}