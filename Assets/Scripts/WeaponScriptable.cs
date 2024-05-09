using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "weapon", menuName = "Items/Create Weapon", order = 0)]
    public class WeaponScriptable : ScriptableObject
    {
        public string weaponName;
        public string description;
        public string weaponType;
        public int damage;
    }
}