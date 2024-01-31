using System.Collections.Generic;
using UnityEngine;

public class SkinsPanel : MonoBehaviour
{
    private List<InventoryItemView> _inventoryItems = new List<InventoryItemView>();

    [SerializeField] private Transform _itemsParent;
    [SerializeField] private InventoryItemViewFactory _inventoryItemViewFactory;

    public void Show(IEnumerable<InventoryItem> items)
    {
        CLear();

        foreach (InventoryItem item in items)
        {
            InventoryItemView spawnedItem = _inventoryItemViewFactory.Get(item, _itemsParent);

            _inventoryItems.Add(spawnedItem);
        }
    }

    private void CLear()
    {
        foreach (InventoryItemView item in _inventoryItems)
        {
            Destroy(item.gameObject);
        }

        _inventoryItems.Clear();
    }
}
