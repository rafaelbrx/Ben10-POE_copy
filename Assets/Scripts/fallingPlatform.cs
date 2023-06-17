using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    public float fallingTime;
    private TargetJoint2D target;
    private BoxCollider2D boxColl; 

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Ben10")
        {
            Invoke("Falling", fallingTime);
        }
    }
    
    void Falling()
    {
        target.enabled = false;
    }
}
