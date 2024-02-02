using UnityEngine;

public class InventoryBootstrap : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private SkinBootstrap _skinBootstrap;

    private IDataProvider _dataProvider;
    private IPersistentData _persistentData;

    private SkinCollector _skinCollector;

    private void Awake()
    {
        InitializeData();
        InitializeInventory();
        InitializeScinCollector();
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
        SkinRemover skinRemover = new SkinRemover(_persistentData);

        _inventory.Initialize(_dataProvider, selectedSkinChecker, _persistentData, skinRemover);
    }

    private void InitializeScinCollector()
    {
        _skinCollector = new SkinCollector(_persistentData, _dataProvider);
        _skinBootstrap.Initialize(_skinCollector);
    }

    private void LoadDataOrInit()
    {
        if (_dataProvider.TryLoad() == false)
            _persistentData.PlayerData = new PlayerData();
    }
}
