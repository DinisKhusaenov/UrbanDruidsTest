using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ArmorSkin : Skin
{
    public event Action<ArmorSkins> Click;

    [SerializeField] private ArmorSkins _armorSkin;

    public ArmorSkins ArmorSkins => _armorSkin;

    public void OnSkinClicked()
    {
        Click?.Invoke(_armorSkin);
        Destroy(gameObject);
    }
}
