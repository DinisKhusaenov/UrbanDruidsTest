using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryContent _inventoryContent;

    [SerializeField] private InventoryCategoryButton _armorSkinsButton;
    [SerializeField] private InventoryCategoryButton _ammoSkinsButton;
    [SerializeField] private InventoryCategoryButton _weaponSkinsButton;

    [SerializeField] private SkinsPanel _skinsPanel;

    private void OnEnable()
    {
        _armorSkinsButton.Click += OnArmorSkinsButtonClick;
        _ammoSkinsButton.Click += OnAmmoSkinsButtonClick;
        _weaponSkinsButton.Click += OnWeaponSkinsButtonClick;
    }

    private void OnDisable()
    {
        _armorSkinsButton.Click -= OnArmorSkinsButtonClick;
        _ammoSkinsButton.Click -= OnAmmoSkinsButtonClick;
        _weaponSkinsButton.Click -= OnWeaponSkinsButtonClick;
    }

    private void OnArmorSkinsButtonClick()
    {
        _skinsPanel.Show(_inventoryContent.ArmorSkinItems.Cast<InventoryItem>());
    }

    private void OnAmmoSkinsButtonClick()
    {
        _skinsPanel.Show(_inventoryContent.AmmoSkinItems.Cast<InventoryItem>());
    }

    private void OnWeaponSkinsButtonClick()
    {
        _skinsPanel.Show(_inventoryContent.WeaponSkinItems.Cast<InventoryItem>());
    }
}
