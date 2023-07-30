using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
public abstract class DamageableUnit : Unit, IDamageable
{
    private UnitHealth _unitHealth;

    protected override void Awake()
    {
        base.Awake();
        _unitHealth = GetComponent<UnitHealth>();
    }

    public void ApplyDamage(float damage)
    {
        _unitHealth.ApplyDamage(damage);
    }
}
