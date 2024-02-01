using System;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPanel : MonoBehaviour
{
    public event Action<InventoryItemView> ItemViewClicked;

    private List<InventoryItemView> _inventoryItems = new List<InventoryItemView>();

    [SerializeField] private Transform _itemsParent;
    [SerializeField] private InventoryItemViewFactory _inventoryItemViewFactory;

    private SelectedSkinChecker _selectedSkinChecker;

    public void Initialize(SelectedSkinChecker selectedSkinChecker)
    {
        _selectedSkinChecker = selectedSkinChecker;
    }

    public void Show(IEnumerable<InventoryItem> items, List<int> itemCount)
    {
        CLear();
        int i = 0;

        foreach (InventoryItem item in items)
        {
            InventoryItemView spawnedItem = _inventoryItemViewFactory.Get(item, _itemsParent);

            spawnedItem.SetCount(itemCount[i]);

            spawnedItem.HideButton();
            spawnedItem.Click += OnItemViewClick;

            _selectedSkinChecker.Visit(spawnedItem.Item);

            if (_selectedSkinChecker.IsSelected)
            {
                spawnedItem.ShowButton();
                ItemViewClicked?.Invoke(spawnedItem);
            }

            _inventoryItems.Add(spawnedItem);
            i++;
        }
    }

    public void Select(InventoryItemView itemView)
    {
        foreach (var item in _inventoryItems)
            item.HideButton();

        itemView.ShowButton();
    }

    private void OnItemViewClick(InventoryItemView inventoryItemView)
    {
        Select(inventoryItemView);
        ItemViewClicked?.Invoke(inventoryItemView);
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
