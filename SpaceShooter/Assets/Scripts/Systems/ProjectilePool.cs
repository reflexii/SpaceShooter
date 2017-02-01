using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : GenericPool<Projectile> {

    protected override void Deactivate(Projectile item)
    {
        item.transform.position = Vector3.zero;
        item.transform.rotation = Quaternion.identity;
        item.rb.velocity = Vector3.zero;

        base.Deactivate(item);
    }
}
