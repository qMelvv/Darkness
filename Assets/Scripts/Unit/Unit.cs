using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected Stats _stats;

    protected virtual void Awake()
    {
        _stats = Instantiate(_stats);
        _stats.Initialize(this);

        foreach (var item in GetComponents<IInitializeStats>())
        {
            item.Initialize(_stats);
        }
    }
}
