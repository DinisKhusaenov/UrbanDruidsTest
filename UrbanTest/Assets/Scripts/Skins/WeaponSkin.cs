using UnityEngine;

public class WeaponSkin : Skin
{
    [SerializeField] private WeaponSkins _weaponSkin;

    public WeaponSkins WeaponSkins => _weaponSkin;
}
