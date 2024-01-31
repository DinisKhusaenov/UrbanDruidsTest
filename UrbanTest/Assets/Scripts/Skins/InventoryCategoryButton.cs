using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCategoryButton : MonoBehaviour
{
    public event Action Click;

    [SerializeField] private Button _button;

    private void OnEnable() => _button.onClick.AddListener(OnClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnClick);

    private void OnClick()
    {
        Click?.Invoke();
    }
}
