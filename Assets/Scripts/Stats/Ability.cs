using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Ability : StatsUpgrade
{
    [SerializeField] private InputActionReference activateAction;
    [SerializeField] private float abilityCooldown;
    [SerializeField] private float abilityDuration;
}
