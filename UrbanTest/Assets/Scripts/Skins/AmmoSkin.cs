using UnityEngine;

public class AmmoSkin : Skin
{
    [SerializeField] private AmmoSkins _ammoSkin;

    public AmmoSkins AmmoSkins => _ammoSkin;
}
