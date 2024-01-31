using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSkinItem", menuName = "Inventory/WeaponSkinItem")]
public class WeaponSkinItem : InventoryItem
{
    [field: SerializeField] public WeaponSkins SkinType { get; private set; }
}
