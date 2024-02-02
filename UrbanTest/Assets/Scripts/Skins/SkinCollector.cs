using System.Collections.Generic;

public class SkinCollector
{
    private IPersistentData _persistentData;
    private IDataProvider _dataProvider;

    public SkinCollector(IPersistentData persistentData, IDataProvider dataProvider)
    {
        _persistentData = persistentData;
        _dataProvider = dataProvider;
    }

    public void Initialize(IEnumerable<WeaponSkin> weaponSkins, IEnumerable<ArmorSkin> armorSkins, IEnumerable<AmmoSkin> ammoSkins)
    {
        foreach (WeaponSkin weapon in weaponSkins)
        {
            weapon.Click += OnWeaponSkinClicked;
        }

        foreach (ArmorSkin armor in armorSkins)
        {
            armor.Click += OnArmorSkinClicked;
        }

        foreach (AmmoSkin ammo in ammoSkins)
        {
            ammo.Click += OnAmmoSkinClicked;
        }
    }

    private void OnWeaponSkinClicked(WeaponSkins weaponSkin)
    {
        _persistentData.PlayerData.AddWeaponSkin(weaponSkin);
        _dataProvider.Save();
    }

    private void OnArmorSkinClicked(ArmorSkins armorSkin)
    {
        _persistentData.PlayerData.AddArmorSkin(armorSkin);
        _dataProvider.Save();
    }

    private void OnAmmoSkinClicked(AmmoSkins ammoSkin)
    {
        _persistentData.PlayerData.AddAmmoSkin(ammoSkin);
        _dataProvider.Save();
    }
}
