using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "armour", menuName = "Items/Create Armour", order = 0)]
    public class armourScritpable : ItemScriptable
    {
        public ItemType ItemType = ItemType.Armour;
        public int defence;
    }
}