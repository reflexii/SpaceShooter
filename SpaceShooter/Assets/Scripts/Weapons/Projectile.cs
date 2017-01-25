using UnityEngine;

public class Projectile : MonoBehaviour {

    public enum ProjectileType
    {
        None = 0,
        Laser = 1,
        Explosive = 2,
        Missile = 3
    }

    [SerializeField]
    private float _shootingForce;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private ProjectileType _projectileType;

    private Rigidbody rb;

    public ProjectileType Type { get { return _projectileType; } }

    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 direction)
    {
        rb.AddForce(direction * _shootingForce, ForceMode.Impulse);
    }

    protected void OnCollisionEnter(Collision col)
    {
        IHealth damageReceiver = col.gameObject.GetComponentInChildren<IHealth>();

        if (damageReceiver != null)
        {
            damageReceiver.TakeDamage(_damage);
            //TODO: Instantiate effect
            //TODO: Add sound effect
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
        {
            Destroy(gameObject);
        }
    }
}
