using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    [SerializeField] private GameUI _gameUI;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _gameUI.IsInventoryActive == false)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.TryGetComponent(out WeaponSkin weapon))
            {
                weapon.OnSkinClicked();
            }

            if (hit.collider != null && hit.collider.TryGetComponent(out ArmorSkin armor))
            {
                armor.OnSkinClicked();
            }

            if (hit.collider != null && hit.collider.TryGetComponent(out AmmoSkin ammo))
            {
                ammo.OnSkinClicked();
            }
        }
    }
}
