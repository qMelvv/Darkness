using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(menuName ="Stats/Stats")]
public class Stats : SerializedScriptableObject
{
    [SerializeField] private Dictionary<StatType, float> baseStats = new();
    [SerializeField] private List<StatsUpgrade> _appliedUpgrades = new();

    private Dictionary<StatType, float> _upgradedStats = new();


    public static float GetUpgradedValue(UpgradeData upgradeData, float value, float baseValue)
    {
        return upgradeData.UpgradeType switch
        {
            UpgradeType.Plus => value + upgradeData.Value,
            UpgradeType.Minus => value - upgradeData.Value,
            UpgradeType.PlusPercent => value + baseValue / 100 * upgradeData.Value,
            UpgradeType.MinusPercent => value - baseValue / 100 * upgradeData.Value,
            _ => throw new ArgumentException()
        };
    }

    [Button]
    public void RecalculateUpgradedStats()
    {
        _upgradedStats.Clear();

        foreach (var stat in baseStats)
        {
            float baseValue = stat.Value;
            float upgradedValue = baseValue;

            foreach (var upgrade in _appliedUpgrades)
            {
                UpgradeData upgradeData;
                if (!upgrade.TryGetUpgradeValue(stat.Key, out upgradeData)) continue;

                upgradedValue = GetUpgradedValue(upgradeData, upgradedValue, baseValue);
            }

            _upgradedStats.Add(stat.Key, upgradedValue);
        }
    }
}

public enum StatType
{
    MaxHealth,
    Speed,
}
