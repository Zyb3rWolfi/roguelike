using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "relic", menuName = "Items/Create Relic", order = 0)]
    public class RelicScriptable : ItemScriptable
    {
        public ItemType ItemType = ItemType.Relic;
    }
}