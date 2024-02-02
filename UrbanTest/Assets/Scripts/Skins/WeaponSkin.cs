using System;
using UnityEngine;

public class WeaponSkin : Skin
{
    public event Action<WeaponSkins> Click;

    [SerializeField] private WeaponSkins _weaponSkin;

    public WeaponSkins WeaponSkins => _weaponSkin;

    public void OnSkinClicked()
    {
        Click?.Invoke(_weaponSkin);
        Destroy(gameObject);
    }
}
