using System;
using System.Collections.Generic;
using UnityEngine;

public class SkinFactory
{
    private IEnumerable<WeaponSkin> _weaponSkins;
    private IEnumerable<AmmoSkin> _ammoSkins;
    private IEnumerable<ArmorSkin> _armorSkins;

    public SkinFactory(IEnumerable<WeaponSkin> weaponSkins, IEnumerable<AmmoSkin> ammoSkins, IEnumerable<ArmorSkin> armorSkins)
    {
        _weaponSkins = weaponSkins;
        _ammoSkins = ammoSkins;
        _armorSkins = armorSkins;
    }

    public WeaponSkin GetWeapon(WeaponSkins weaponSkin)
    {
        foreach (var skin in _weaponSkins)
        {
            if (skin.WeaponSkins == weaponSkin)
                return GameObject.Instantiate(skin);
        }

        throw new ArgumentException(nameof(weaponSkin));
    }

    public ArmorSkin GetArmor(ArmorSkins armorSkin)
    {
        foreach (var skin in _armorSkins)
        {
            if (skin.ArmorSkins == armorSkin)
                return GameObject.Instantiate(skin);
        }

        throw new ArgumentException(nameof(armorSkin));
    }

    public AmmoSkin GetAmmo(AmmoSkins ammoSkin)
    {
        foreach (var skin in _ammoSkins)
        {
            if (skin.AmmoSkins == ammoSkin)
                return GameObject.Instantiate(skin);
        }

        throw new ArgumentException(nameof(ammoSkin));
    }
}
