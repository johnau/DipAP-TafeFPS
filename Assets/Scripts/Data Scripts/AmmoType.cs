using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AmmoType : ScriptableObject
{
    [Tooltip("Maximum amount of this ammo that can be held by the player")]
    public int maximumCapacity = 50;
    [Tooltip("Damage dealt per hit with this ammo")]
    public int damage = 1;


}
