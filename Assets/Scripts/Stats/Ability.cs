using UnityEngine;

public abstract class Ability : StatsUpgrade, IInitialize<Unit>
{
    public bool IsActive { get; private set; } = false;

    [SerializeField] private float duration;
    [SerializeField] private float cooldown;

    private Unit _unit;


    public void Initialize(Unit instance)
        => _unit = instance;
}
