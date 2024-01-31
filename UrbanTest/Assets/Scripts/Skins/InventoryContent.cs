using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryContent", menuName = "Inventory/InventoryContent")]
public class InventoryContent : ScriptableObject
{
    [SerializeField] private List<WeaponSkinItem> _weaponSkinItems;
    [SerializeField] private List<ArmorSkinItem> _armorSkinItems;
    [SerializeField] private List<AmmoSkinItem> _ammoSkinItems;

    public IEnumerable<WeaponSkinItem> WeaponSkinItems => _weaponSkinItems;
    public IEnumerable<ArmorSkinItem> ArmorSkinItems => _armorSkinItems;
    public IEnumerable<AmmoSkinItem> AmmoSkinItems => _ammoSkinItems;

    private void OnValidate()
    {
        var weaponSkinDublicates = _weaponSkinItems.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if (weaponSkinDublicates.Count() > 0)
            throw new InvalidOperationException(nameof(_weaponSkinItems));

        var armorSkinDublicates = _armorSkinItems.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if (armorSkinDublicates.Count() > 0)
            throw new InvalidOperationException(nameof(_armorSkinItems));

        var ammoSkinDublicates = _ammoSkinItems.GroupBy(item => item.SkinType)
            .Where(array => array.Count() > 1);

        if (ammoSkinDublicates.Count() > 0)
            throw new InvalidOperationException(nameof(_ammoSkinItems));
    }
}
