using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Stats/Upgrade")]
public class StatsUpgrade : SerializedScriptableObject
{
    [SerializeField] protected Dictionary<StatType, UpgradeData> statsToUpgrade = new();

    public bool TryGetUpgradeValue(StatType statType, out UpgradeData data)
        => statsToUpgrade.TryGetValue(statType, out data);
}
