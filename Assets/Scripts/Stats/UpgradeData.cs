using UnityEngine;

[System.Serializable]
public struct UpgradeData
{
    [SerializeField] private float value;
    [SerializeField] private UpgradeType upgradeType;

    public float Value => value;
    public UpgradeType UpgradeType => upgradeType;
}
