using UnityEngine;

/// <summary>
/// A gun that fires projectile objects rather than hitscanning with raycasts
/// </summary>
[CreateAssetMenu()]
public class ProjectileGun : GunData
{
    [Header("Projectile Gun")]
    public GameObject projectile;
}
