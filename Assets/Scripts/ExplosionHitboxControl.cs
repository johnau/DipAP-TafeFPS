using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHitboxControl : MonoBehaviour
{
    public AmmoType type; // for the damage
    HashSet<GameObject> collidedObjs = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        TakeDamageTest hitObj = other.GetComponent<TakeDamageTest>();
        if (hitObj != null && !collidedObjs.Contains(hitObj.ReturnParentObj()))
        {
            hitObj.TakeDamage(type.damage);
            collidedObjs.Add(hitObj.ReturnParentObj());
        }
    }

}
