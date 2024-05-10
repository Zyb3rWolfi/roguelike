using DefaultNamespace.Inventory;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Create Enemy", order = 0)]
    public class EnemyTypes : ScriptableObject
    {
        [Header("Enemy Name")]
        public string enemyName;
        [Header("Enemy Stats")]
        public int health;
        public int damage;
        public float speed;
        public int followDistance;
        [Header("Drops")]
        public DropTableScriptable dropTable;
    }
}