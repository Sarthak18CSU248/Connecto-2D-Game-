using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingPlatform : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        CollapsePlatform();
    }
    public void CollapsePlatform()
   {
        Rigidbody2D rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.bodyType = RigidbodyType2D.Dynamic;
        rigidbody2d.mass = 3;
   }
}
