using UnityEngine;

public class InventoryBootstrap : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private IDataProvider _dataProvider;
    private IPersistentData _persistentData;

    private void Awake()
    {
        InitializeData();
        InitializeInventory();
    }

    private void InitializeData()
    {
        _persistentData = new PersistentData();
        _dataProvider = new DataLocalProvider(_persistentData);

        LoadDataOrInit();
    }

    private void InitializeInventory()
    {
        SelectedSkinChecker selectedSkinChecker = new SelectedSkinChecker(_persistentData);

        _inventory.Initialize(_dataProvider, selectedSkinChecker, _persistentData);
    }

    private void LoadDataOrInit()
    {
        if (_dataProvider.TryLoad() == false)
            _persistentData.PlayerData = new PlayerData();
    }
}
