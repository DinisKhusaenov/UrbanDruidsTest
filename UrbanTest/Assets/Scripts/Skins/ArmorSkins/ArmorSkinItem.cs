using UnityEngine;

[CreateAssetMenu(fileName = "ArmorSkinItem", menuName = "Inventory/ArmorSkinItem")]
public class ArmorSkinItem : InventoryItem
{
    [field: SerializeField] public ArmorSkins SkinType { get; private set; }
}
