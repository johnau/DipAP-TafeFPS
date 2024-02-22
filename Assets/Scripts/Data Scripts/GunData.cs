using UnityEngine;

[CreateAssetMenu()]
public class GunData : ScriptableObject
{
    [Tooltip("The prefab of the gun that gets loaded into the player's hands")]
    public GameObject prefab;
    
    [Tooltip("Is the gun single shot or auto")]
    public bool isAutomatic = false;

    [Tooltip("The time between shots for this weapon")]
    public float fireRate = 0.1f;

    [Tooltip("The type of ammo used by this weapon")]
    public AmmoType ammoType;

    [Tooltip("Offset for spawning the gun into the player's hands")]
    public Vector3 pivotOffset;

    [Header("Effects")]
    [Tooltip("The projectile launched by the gun")]
    public GameObject E_bullet;
    [Tooltip("Effect produced at muzzle location when gun is fired")]
    public GameObject E_muzzleFlash;
    [Tooltip("Effect created at point of bullet/projectile impact")]
    public GameObject E_hitEffect;
    [Tooltip("Texture left bheind after bullet impact")]
    public GameObject E_bulletMark;

    [Header("Audio")]
    [Tooltip("SFX for firing the gun")]
    public AudioClip A_fire;
    [Tooltip("SFX for attempting tofire the gun without ammo")]
    public AudioClip A_dryFire;
    [Tooltip("SFX for the bullet hitting it's target")]
    public AudioClip A_impact;

}
