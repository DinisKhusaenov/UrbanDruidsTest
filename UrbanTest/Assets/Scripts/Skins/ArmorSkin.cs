using UnityEngine;

public class ArmorSkin : Skin
{
    [SerializeField] private ArmorSkins _armorSkin;

    public ArmorSkins ArmorSkins => _armorSkin;
}
