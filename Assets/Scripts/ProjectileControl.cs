using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{

    public float speed = 20f;
    //public AmmoType ammoType; // for the damage

    public CapsuleCollider refCollider;
    Vector3 point1Offset;
    Vector3 point2Offset;
    Vector3 forwardVector = new Vector3(0, 0, 1);
    public LayerMask hitMask;
    

    [Header("Explosion")]
    public bool explodes = true;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        switch (refCollider.direction) {
            case 0: // X
                point1Offset = new Vector3(refCollider.bounds.extents.x, 0f, 0f);
                point1Offset = new Vector3(-refCollider.bounds.extents.x, 0f, 0f);
                break;
            case 1: // Y
                point1Offset = new Vector3(0f, refCollider.bounds.extents.y, 0f);
                point1Offset = new Vector3(0f, -refCollider.bounds.extents.y, 0f);
                break;
            case 2: // Z
                point1Offset = new Vector3(0f, 0f, refCollider.bounds.extents.z);
                point1Offset = new Vector3(0f, 0f, -refCollider.bounds.extents.z);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector2 nextMove = speed * Time.deltaTime * forwardVector;
        if (Physics.CapsuleCast(
            transform.position + point1Offset, 
            transform.position + point2Offset, 
            refCollider.radius, 
            transform.forward,
            out hit,
            nextMove.magnitude, 
            hitMask))
        {
            Explode(hit.point);
        }

        transform.Translate(nextMove); // forward vector
    }

    void Explode(Vector3 hitPos)
    {
        Instantiate(explosionPrefab, hitPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
