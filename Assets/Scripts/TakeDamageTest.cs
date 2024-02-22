using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageTest : MonoBehaviour
{
    [SerializeField]
    GameObject parent;

    public GameObject ReturnParentObj()
    {
        if (parent == null)
        {
            return transform.parent.gameObject;
        }
        return parent;
    }


    public int health = 100;
    int damageTaken = 0;

    public void TakeDamage(int damage)
    {
        if (damageTaken >= health) 
        {
            print(gameObject.name + " is dead!");
        } 
        else
        {
            print(gameObject.name + " took " + damage + " point of damage");
            damageTaken += damage;
        }
    }
}
