using System.Collections;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IInitializeStats
{
    private const float InvincibleDuration = 0.1f;
    public float Health { get; private set; }

    private Stats _stats;

    private bool _isInvincible = false;


    private IEnumerator BecomeTemporarilyInvincible()
    {
        _isInvincible = true;
        yield return new WaitForSeconds(InvincibleDuration);
        _isInvincible = false;
    }

    public void Initialize(Stats instance)
    {
        _stats = instance;
    }

    public void ApplyDamage(float damage)
    {
        if (!_isInvincible) return;

        StartCoroutine(BecomeTemporarilyInvincible());
    }

}
