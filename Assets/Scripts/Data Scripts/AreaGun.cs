using UnityEngine;

/// <summary>
/// Fires a number of raycasted projectiles in an area rather than a single projectile
/// </summary>
[CreateAssetMenu()]
public class AreaGun : GunData
{
    [Header("Area Gun")]
    [Tooltip("How many bullets are fired per shot of this weapon")]
    public int shotCount = 10;
    [Tooltip("The radius off the randomised spread of the shots from the shell")]
    public float spreadRadius = 1f;
    [Tooltip("The optimum effectiveness range of the weapon")]
    public float range = 10f;
}
