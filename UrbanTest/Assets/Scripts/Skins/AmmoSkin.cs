using System;
using UnityEngine;

public class AmmoSkin : Skin
{
    public event Action<AmmoSkins> Click;

    [SerializeField] private AmmoSkins _ammoSkin;

    public AmmoSkins AmmoSkins => _ammoSkin;

    public void OnSkinClicked()
    {
        Click?.Invoke(_ammoSkin);
        Destroy(gameObject);
    }
}
