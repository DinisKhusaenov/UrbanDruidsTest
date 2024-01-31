using UnityEngine;

public abstract class InventoryItem : ScriptableObject
{
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField] public StatusConfig StatusConfig { get; private set; }
}
