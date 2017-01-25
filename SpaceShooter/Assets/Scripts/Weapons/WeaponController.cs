using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private float shootingSpeed;

    private float shootingRate;
    private float previouslyShot;
    private Weapon[] weapons;

    //TODO: Add support for booster

    protected void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>();
        shootingRate = 1f / shootingSpeed;
        previouslyShot = shootingRate;
    }

    protected void Update()
    {
        previouslyShot += Time.deltaTime;
    }

    public void Shoot(int projectileLayer)
    {
        if (previouslyShot >= shootingRate)
        {
            previouslyShot = 0f;

            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].Shoot(projectileLayer);
            }
        }
    }
}
