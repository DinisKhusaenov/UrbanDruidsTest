using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerData
{
    private Dictionary<ArmorSkins, int> _inventoryArmorSkins;
    private Dictionary<AmmoSkins, int> _inventoryAmmoSkins;
    private Dictionary<WeaponSkins, int> _inventoryWeaponSkins;

    private ArmorSkins _selectedArmorSkin;
    private AmmoSkins _selectedAmmoSkin;
    private WeaponSkins _selectedWeaponSkin;

    public PlayerData()
    {
        _inventoryArmorSkins = new Dictionary<ArmorSkins, int>();
        _inventoryAmmoSkins = new Dictionary<AmmoSkins, int>();
        _inventoryWeaponSkins = new Dictionary<WeaponSkins, int>();

        SelectInitialSkin();
    }

    [JsonConstructor]
    public PlayerData(Dictionary<ArmorSkins, int> inventoryArmorSkins, Dictionary<AmmoSkins, int> inventoryAmmoSkins, 
        Dictionary<WeaponSkins, int> inventoryWeaponSkins, ArmorSkins selectedArmorSkin, AmmoSkins selectedAmmoSkin, WeaponSkins selectedWeaponSkin)
    {
        _inventoryArmorSkins = new Dictionary<ArmorSkins, int>(inventoryArmorSkins);
        _inventoryAmmoSkins = new Dictionary<AmmoSkins, int>(inventoryAmmoSkins);
        _inventoryWeaponSkins = new Dictionary<WeaponSkins, int>(inventoryWeaponSkins);

        _selectedAmmoSkin = selectedAmmoSkin;
        _selectedWeaponSkin = selectedWeaponSkin;
        _selectedArmorSkin = selectedArmorSkin;
    }

    public IReadOnlyDictionary<ArmorSkins, int> InventoryArmorSkins => _inventoryArmorSkins;

    public IReadOnlyDictionary<AmmoSkins, int> InventoryAmmoSkins => _inventoryAmmoSkins;

    public IReadOnlyDictionary<WeaponSkins, int> InventoryWeaponSkins => _inventoryWeaponSkins;

    public AmmoSkins SelectedAmmoSkin
    {
        get => _selectedAmmoSkin;
        set => _selectedAmmoSkin = value;
    }

    public ArmorSkins SelectedArmorSkin
    {
        get => _selectedArmorSkin;
        set => _selectedArmorSkin = value;
    }

    public WeaponSkins SelectedWeaponSkin
    {
        get => _selectedWeaponSkin;
        set => _selectedWeaponSkin = value;
    }

    public void AddArmorSkin(ArmorSkins armorSkin)
    {
        if (_inventoryArmorSkins.ContainsKey(armorSkin)) 
        {
            var count = _inventoryArmorSkins[armorSkin];
            _inventoryArmorSkins[armorSkin] = count + 1;
        }
        else
        {
            _inventoryArmorSkins.Add(armorSkin, 1);
        }
    }

    public void AddAmmoSkin(AmmoSkins ammoSkin)
    {
        if (_inventoryAmmoSkins.ContainsKey(ammoSkin))
        {
            var count = _inventoryAmmoSkins[ammoSkin];
            _inventoryAmmoSkins[ammoSkin] = count + 1;
        }
        else
        {
            _inventoryAmmoSkins.Add(ammoSkin, 1);
        }
    }

    public void AddWeaponSkin(WeaponSkins weaponSkin)
    {
        if (_inventoryWeaponSkins.ContainsKey(weaponSkin))
        {
            var count = _inventoryWeaponSkins[weaponSkin];
            _inventoryWeaponSkins[weaponSkin] = count + 1;
        }
        else
        {
            _inventoryWeaponSkins.Add(weaponSkin, 1);
        }
    }

    public void RemoveArmorSkin(ArmorSkins armorSkin)
    {
        if (_inventoryArmorSkins.ContainsKey(armorSkin))
        {
            _inventoryArmorSkins.Remove(armorSkin);
            SelectInitialSkin();
        }
    }

    public void RemoveAmmoSkin(AmmoSkins ammoSkin)
    {
        if (_inventoryAmmoSkins.ContainsKey(ammoSkin))
        {
            _inventoryAmmoSkins.Remove(ammoSkin);
            SelectInitialSkin();
        }
    }

    public void RemoveWeaponSkin(WeaponSkins weaponSkin)
    {
        if (_inventoryWeaponSkins.ContainsKey(weaponSkin))
        {
            _inventoryWeaponSkins.Remove(weaponSkin);
            SelectInitialSkin();
        }
    }

    private void SelectInitialSkin()
    {
        _selectedAmmoSkin = AmmoSkins.ButtleBow;
        _selectedArmorSkin = ArmorSkins.BanditLight;
        _selectedWeaponSkin = WeaponSkins.AssassinDagger;
    }
}
