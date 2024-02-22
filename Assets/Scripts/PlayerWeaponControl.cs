using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponControl : MonoBehaviour
{
    public Camera viewCamera;
    public LayerMask hitMask;
    public GunData currentWeaponData;
    public GunControl currentGun;

    // "this is not the best way to handle ammo..... this is a bit dodgy" - Tom
    public List<AmmoType> ammoTypes = new List<AmmoType>();
    public Dictionary<AmmoType, int> ammoStore = new Dictionary<AmmoType, int>();
    
    bool resetting = false;
    float nextFireTime = 0f;

    Coroutine automaticRoutine;

    // Start is called before the first frame update
    void Start()
    {
        //ammoStore[ammoTypes[0]] = 0;
        InitializeAmmo();
    }

    void InitializeAmmo()
    {
        for(int i = 0; i < ammoTypes.Count; i++)
        {
            ammoStore.Add(ammoTypes[i], ammoTypes[i].maximumCapacity);
        }
    }

    public void Fire()
    {
        if (currentWeaponData.isAutomatic)
        {
            automaticRoutine = StartCoroutine(AutomaticRoutine());
        }
        else
        {
            BulletFire();
        }
    }

    public void EndFire()
    {
        if (automaticRoutine != null)
        {
            StopCoroutine(automaticRoutine);
        }
    }

    IEnumerator AutomaticRoutine()
    {
        while (ammoStore[currentWeaponData.ammoType] > 0)
        {
            BulletFire();
            yield return new WaitUntil(() => Time.time >= nextFireTime);
        }
        BulletFire(); // run one last time to hit the empty clip sound (could be made more efficient? break out the empty clip sound into a separate method)
    }

    void BulletFire()
    {
        if (resetting)
        {
            if (Time.time >= nextFireTime)
            {
                resetting = false;
            }
            else
            {
                return;
            }
        }

        // out of ammo

        if (ammoStore[currentWeaponData.ammoType] <= 0)
        {
            // play empty clip sound
            return;
        }
        else
        {
            UpdateAmmo(-1, currentWeaponData.ammoType);
        }

        Instantiate(currentWeaponData.E_muzzleFlash, currentGun.muzzle.position, currentGun.muzzle.rotation, currentGun.muzzle);

        Vector3 bulletDir = ((viewCamera.transform.position + viewCamera.transform.forward * 1000) - currentGun.muzzle.position).normalized;
        bool didHit = false;
        RaycastHit hit;
        if (Physics.Raycast(viewCamera.transform.position, viewCamera.transform.forward, out hit, Mathf.Infinity, hitMask))
        {
            TakeDamageTest hitObj = hit.collider.GetComponent<TakeDamageTest>();
            if (hitObj != null)
            {
                hitObj.TakeDamage(currentWeaponData.ammoType.damage);
            }

            print(hit.collider.gameObject.name + " was hit at " + hit.point);
            Instantiate(currentWeaponData.E_hitEffect, hit.point, Quaternion.identity);
            bulletDir = (hit.point - currentGun.muzzle.position).normalized;
        }

        Instantiate(currentWeaponData.E_bullet,
            currentGun.muzzle.position,
            Quaternion.LookRotation(bulletDir)).GetComponent<BulletControl>().Initialize(didHit, hit.point);

        resetting = true;
        nextFireTime = Time.time + currentWeaponData.fireRate;
    }

    //void UpdateAmmo(int value) {
    //    ammoStore[currentWeaponData.ammoType] += Mathf.Clamp(ammoStore[currentWeaponData.ammoType] + value, 0, currentWeaponData.ammoType.maximumCapacity);
    //    // update gui
    //}   
    void UpdateAmmo(int value, AmmoType type) {
        ammoStore[type] = Mathf.Clamp(ammoStore[type] + value, 0, type.maximumCapacity);
        if (type == currentWeaponData.ammoType)
        {
            // update gui
        }
    }

    public void AmmoPickup(int value, AmmoType type)
    {
        UpdateAmmo(value, type);
    }

}
