using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemViewFactory", menuName = "Inventory/InventoryItemViewFactory")]
public class InventoryItemViewFactory : ScriptableObject
{
    [SerializeField] private InventoryItemView _armorSkinItemPrefab;
    [SerializeField] private InventoryItemView _ammoSkinItemPrefab;
    [SerializeField] private InventoryItemView _weaponSkinItemPrefab;

    public InventoryItemView Get(InventoryItem inventoryItem, Transform parent)
    {
        InventoryItemView instance;

        switch (inventoryItem)
        {
            case ArmorSkinItem armorSkinItem:
                instance = Instantiate(_armorSkinItemPrefab, parent);
                break;

            case AmmoSkinItem ammoSkinItem:
                instance = Instantiate(_ammoSkinItemPrefab, parent);
                break;

            case WeaponSkinItem weaponSkinItem:
                instance = Instantiate(_weaponSkinItemPrefab, parent);
                break;

            default:
                throw new ArgumentException(nameof(inventoryItem));
        }

        instance.Initialize(inventoryItem);
        return instance;
    }
}
