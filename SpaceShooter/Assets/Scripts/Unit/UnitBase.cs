using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class UnitBase : MonoBehaviour {
    public IHealth Health { get; protected set; }
    public IMover Mover { get; protected set; }

    protected virtual void Awake()
    {
        Health = gameObject.GetOrAddComponent<Health>();
        Mover = gameObject.GetOrAddComponent<Mover>();
    }

    public void TakeDamage(int amount)
    {
        if (Health.TakeDamage(amount))
        {
            Die();
        }
    }

    #region Abstracts
    protected abstract void Die();
    public abstract int ProjectileLayer { get; }
    #endregion
}
