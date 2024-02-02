public class SkinRemover : IInventoryItemVisitor
{
    private IPersistentData _persistentData;

    public SkinRemover(IPersistentData persistentData)
    {
        _persistentData = persistentData;
    }

    public void Visit(InventoryItem inventoryItem) => Visit((dynamic) inventoryItem);

    public void Visit(ArmorSkinItem armorSkinItem)
        => _persistentData.PlayerData.RemoveArmorSkin(armorSkinItem.SkinType);

    public void Visit(AmmoSkinItem ammoSkinItem)
        => _persistentData.PlayerData.RemoveAmmoSkin(ammoSkinItem.SkinType);

    public void Visit(WeaponSkinItem weaponSkinItem)
        => _persistentData.PlayerData.RemoveWeaponSkin(weaponSkinItem.SkinType);
}
