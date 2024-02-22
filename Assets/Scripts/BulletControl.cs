using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public LineRenderer line;
    public float speed = 50f;

    bool hit = false;
    Vector3 impactSite;

    public void Initialize(bool hit, Vector3 impactSite)
    {
        this.impactSite = impactSite;
        this.hit = hit;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (hit)
        {
            SortLine();
        }
    }

    void SortLine()
    {
        for(int i = line.positionCount-1; i >= 0; i--)
        {
            Vector3 linePos = line.GetPosition(i);
            if (Vector3.Distance(linePos, transform.position) > Vector3.Distance(impactSite, transform.position))
            {
                line.SetPosition(i, transform.InverseTransformPoint(impactSite));
                if (i == 0) // destroy self if the entire line is at the impact site
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
