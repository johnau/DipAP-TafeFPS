using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AmmoType ammoType;
    public int ammo = 50;
    
    public void Clear()
    {
        Destroy(gameObject);
    }
}
