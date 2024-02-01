public class SelectedSkinChecker : IInventoryItemVisitor
{
    private IPersistentData _persistentData;

    public SelectedSkinChecker(IPersistentData persistentData)
    {
        _persistentData = persistentData;
    }

    public bool IsSelected { get; private set; }

    public void Visit(InventoryItem inventoryItem) => Visit((dynamic)inventoryItem);

    public void Visit(ArmorSkinItem armorSkinItem)
        => IsSelected = _persistentData.PlayerData.SelectedArmorSkin == armorSkinItem.SkinType;

    public void Visit(AmmoSkinItem ammoSkinItem)
        => IsSelected = _persistentData.PlayerData.SelectedAmmoSkin == ammoSkinItem.SkinType;

    public void Visit(WeaponSkinItem weaponSkinItem)
                => IsSelected = _persistentData.PlayerData.SelectedWeaponSkin == weaponSkinItem.SkinType;
}
