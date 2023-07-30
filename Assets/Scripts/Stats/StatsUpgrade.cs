using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Stats/Upgrade")]
public class StatsUpgrade : SerializedScriptableObject
{
    [SerializeField]
    protected Dictionary<StatType, UpgradeData> upgradesToApply = new();

    public IReadOnlyDictionary<StatType, UpgradeData> UpgradesToApply
        => upgradesToApply;
}
