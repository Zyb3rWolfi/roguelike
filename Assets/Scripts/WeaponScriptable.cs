using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "weapon", menuName = "Items/Create Weapon", order = 0)]
    public class WeaponScriptable : ItemScriptable
    {
        public int damage;
        public ItemType ItemType = ItemType.Weapon;
    }
}