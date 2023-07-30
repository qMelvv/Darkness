using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Stats/Stats")]
public class Stats : SerializedScriptableObject, IInitialize<Unit>
{
    [SerializeField] private Dictionary<StatType, float> baseStats = new();

    private Dictionary<StatType, float> _upgradedStats = new();

    private List<StatsUpgrade> _appliedStaticUpgrades = new();
    private List<Ability> _abilities;

    private Unit _unit;


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

    private void RecalculateUpgradedStats()
    {
        _upgradedStats.Clear();

        foreach (var stat in baseStats)
        {
            float baseValue = stat.Value;
            float upgradedValue = baseValue;

            foreach (var upgrade in _appliedStaticUpgrades)
            {
                UpgradeData upgradeData;
                if (!upgrade.UpgradesToApply.TryGetValue(stat.Key, out upgradeData))
                    continue;

                upgradedValue = GetUpgradedValue(upgradeData, upgradedValue, baseValue);
            }

            _upgradedStats.Add(stat.Key, upgradedValue);
        }
    }

    public void Initialize(Unit instance)
        => _unit = instance;

    public void UnlockAbility(Ability ability)
    {
        ability = Instantiate(ability);
        ability.Initialize(_unit);

        _abilities.Add(ability);
    }

    public void UnlockUpgrade(StatsUpgrade upgrade)
    {
        _appliedStaticUpgrades.Add(upgrade);
        RecalculateUpgradedStats();
    }
}
