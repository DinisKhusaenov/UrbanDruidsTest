using UnityEngine;

[CreateAssetMenu(fileName = "AmmoSkinItem", menuName = "Inventory/AmmoSkinItem")]
public class AmmoSkinItem : InventoryItem
{
    [field: SerializeField] public AmmoSkins SkinType { get; private set; }
}
