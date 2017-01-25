using System;
using UnityEngine;

public class PlayerUnit : UnitBase
{

    public Mover mover;
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

    public void Update()
    {
        shipMovement();
        shootWeapons();
    }

    private void shipMovement()
    {
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mover.MoveToDirection(Vector3.left);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mover.MoveToDirection(Vector3.right);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mover.MoveToDirection(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mover.MoveToDirection(Vector3.back);
        }
        */

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        mover.MoveToDirection(new Vector3(horizontal, 0f, vertical));
    }

    private void shootWeapons()
    {
        bool shoot = Input.GetButton("Shoot");
        if (shoot)
        {
            Weapons.Shoot(ProjectileLayer);
        }
    }
}
