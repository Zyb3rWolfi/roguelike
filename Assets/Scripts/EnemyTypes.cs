using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Create Type", order = 0)]
    public class EnemyTypes : ScriptableObject
    {
        public string enemyName;
        public int health;
        public int damage;
        public float speed;
    }
}