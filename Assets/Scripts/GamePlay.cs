using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            Destroy(this.gameObject);
            if(gameObject.tag=="end")
            {
                Application.Quit();
            }
        }
    }
}
