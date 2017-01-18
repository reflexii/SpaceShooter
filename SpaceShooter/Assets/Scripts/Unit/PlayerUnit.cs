using System;
using UnityEngine;

public class PlayerUnit : UnitBase
{
    public enum UnitType
    {
        None = 0,
        Fast,
        Balanced,
        Heavy
    }
    public override int ProjectileLayer
    {
        get
        {
            return LayerMask.NameToLayer("PlayerProjectile");
        }
    }

    protected override void Die()
    {
        //TODO: Handle dying properly!
        gameObject.SetActive(false);
    }
}
