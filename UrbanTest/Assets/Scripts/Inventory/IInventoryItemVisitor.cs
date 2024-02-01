public interface IInventoryItemVisitor 
{
    void Visit(InventoryItem inventoryItem);
    void Visit(ArmorSkinItem armorSkinItem);
    void Visit(AmmoSkinItem ammoSkinItem);
    void Visit(WeaponSkinItem weaponSkinItem);
}
