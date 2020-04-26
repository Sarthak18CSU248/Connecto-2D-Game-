using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWay : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<EdgeCollider2D>().enabled = false;
            Invoke("ColliderPlatfrom", 1f);
        }

    }
    public void ColliderPlatfrom()
    {
        gameObject.GetComponent<EdgeCollider2D>().enabled = true;
    }
}
