using UnityEngine;

[CreateAssetMenu(fileName = "StatusConfig", menuName = "Inventory/StatusConfig")]
public class StatusConfig : ScriptableObject
{
    [field: SerializeField] public Sprite StatusImage { get; private set; }
    [field: SerializeField] public int StatusBoost { get; private set; }
    [field: SerializeField] public StatusTypes StatusType { get; private set; }
}
