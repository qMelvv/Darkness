using UnityEngine;

[System.Serializable]
public struct UpgradeData
{
    [field: SerializeField] public float Value { get; private set; }
    [field: SerializeField] public UpgradeType UpgradeType { get; private set; }
}
