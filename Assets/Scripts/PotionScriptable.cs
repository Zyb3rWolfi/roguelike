using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Items/Create Potion", order = 0)]
    public class PotionScriptable : ItemScriptable
    {
        public ItemType ItemType = ItemType.Consumable;
        public int healAmount;
    }
}