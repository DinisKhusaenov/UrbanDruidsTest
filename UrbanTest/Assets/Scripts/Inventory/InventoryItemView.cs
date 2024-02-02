using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour, IPointerClickHandler
{
    public event Action<InventoryItemView> Click;
    public event Action<InventoryItemView> Destroyed;

    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _statusImage;
    [SerializeField] private IntValueView _statusBoost;
    [SerializeField] private IntValueView _count;
    [SerializeField] private Button _delete;

    public InventoryItem Item { get; private set; }

    public int StatusBoost => Item.StatusConfig.StatusBoost;

    public void Initialize(InventoryItem inventoryItem)
    {
        Item = inventoryItem;

        _contentImage.sprite = Item.Image;
        _statusImage.sprite = Item.StatusConfig.StatusImage;
        _statusBoost.Show(StatusBoost);
        HideButton();
    }

    private void OnEnable()
    {
        _delete.onClick.AddListener(Delete);
    }

    private void OnDisable()
    {
        _delete.onClick.RemoveListener(Delete);
    }

    public void OnPointerClick(PointerEventData eventData) => Click?.Invoke(this);

    public void SetCount(int value)
    {
        if (value <= 0)
            throw new ArgumentException(nameof(value));

        _count.Show(value);
    }

    public void ShowButton() => _delete.gameObject.SetActive(true);

    public void HideButton() => _delete.gameObject.SetActive(false);

    private void Delete()
    {
        Destroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
