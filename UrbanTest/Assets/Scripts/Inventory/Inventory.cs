using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryContent _inventoryContent;

    [SerializeField] private InventoryCategoryButton _armorSkinsButton;
    [SerializeField] private InventoryCategoryButton _ammoSkinsButton;
    [SerializeField] private InventoryCategoryButton _weaponSkinsButton;

    [SerializeField] private SkinsPanel _skinsPanel;

    private List<int> _weaponSkinCount;
    private List<int> _armorSkinCount;
    private List<int> _ammoSkinCount;

    private IDataProvider _dataProvider;
    private IPersistentData _persistentData;

    private SelectedSkinChecker _selectedSkinChecker;
    private InventoryItemView _previewedItem;

    public void Initialize(IDataProvider dataProvider, SelectedSkinChecker selectedSkinChecker, IPersistentData persistentData)
    {
        _dataProvider = dataProvider;
        _selectedSkinChecker = selectedSkinChecker;
        _persistentData = persistentData;

        _weaponSkinCount = new List<int>();
        _armorSkinCount = new List<int>();
        _ammoSkinCount = new List<int>();

        _skinsPanel.Initialize(selectedSkinChecker);
    }

    private void OnEnable()
    {
        _armorSkinsButton.Click += OnArmorSkinsButtonClick;
        _ammoSkinsButton.Click += OnAmmoSkinsButtonClick;
        _weaponSkinsButton.Click += OnWeaponSkinsButtonClick;

        _skinsPanel.ItemViewClicked += OnItemViewClicked;
    }

    private void OnDisable()
    {
        _armorSkinsButton.Click -= OnArmorSkinsButtonClick;
        _ammoSkinsButton.Click -= OnAmmoSkinsButtonClick;
        _weaponSkinsButton.Click -= OnWeaponSkinsButtonClick;

        _skinsPanel.ItemViewClicked -= OnItemViewClicked;
    }

    private void OnArmorSkinsButtonClick()
    {
        _skinsPanel.Show(GetArmorData().Cast<InventoryItem>(), new List<int>(_armorSkinCount));
    }

    private void OnAmmoSkinsButtonClick()
    {
        _skinsPanel.Show(GetAmmoData().Cast<InventoryItem>(), new List<int>(_ammoSkinCount));
    }

    private void OnWeaponSkinsButtonClick()
    {
        _skinsPanel.Show(GetWeaponData().Cast<InventoryItem>(), new List<int>(_weaponSkinCount));
    }

    private void OnItemViewClicked(InventoryItemView item)
    {
        _previewedItem = item;

        _selectedSkinChecker.Visit(_previewedItem.Item);

        if (_selectedSkinChecker.IsSelected)
            return;

        SelectSkin();
    }

    private void SelectSkin()
    {
        _selectedSkinChecker.Visit(_previewedItem.Item);
        _skinsPanel.Select(_previewedItem);

        _dataProvider.Save();
    }

    private List<WeaponSkinItem> GetWeaponData()
    {
        List<WeaponSkinItem> weaponSkinItems = new List<WeaponSkinItem>();
        _weaponSkinCount.Clear();

        foreach (WeaponSkinItem item in _inventoryContent.WeaponSkinItems)
        {
            if (_persistentData.PlayerData.InventoryWeaponSkins.ContainsKey(item.SkinType))
            {
                weaponSkinItems.Add(item);
                _weaponSkinCount.Add(_persistentData.PlayerData.InventoryWeaponSkins[item.SkinType]);
            }
        }

        return weaponSkinItems;
    }

    private List<AmmoSkinItem> GetAmmoData()
    {
        List<AmmoSkinItem> ammoSkinItems = new List<AmmoSkinItem>();
        _ammoSkinCount.Clear();

        foreach (AmmoSkinItem item in _inventoryContent.AmmoSkinItems)
        {
            if (_persistentData.PlayerData.InventoryAmmoSkins.ContainsKey(item.SkinType))
            {
                ammoSkinItems.Add(item);
                _ammoSkinCount.Add(_persistentData.PlayerData.InventoryAmmoSkins[item.SkinType]);
            }
        }

        return ammoSkinItems;
    }

    private List<ArmorSkinItem> GetArmorData()
    {
        List<ArmorSkinItem> armorSkinItems = new List<ArmorSkinItem>();
        _armorSkinCount.Clear();

        foreach (ArmorSkinItem item in _inventoryContent.ArmorSkinItems)
        {
            if (_persistentData.PlayerData.InventoryArmorSkins.ContainsKey(item.SkinType))
            {
                armorSkinItems.Add(item);
                _armorSkinCount.Add(_persistentData.PlayerData.InventoryArmorSkins[item.SkinType]);
            }
        }

        return armorSkinItems;
    }
}
