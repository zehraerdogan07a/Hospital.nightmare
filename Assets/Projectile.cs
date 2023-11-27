using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public void Init(Vector2 velocity)
    {
        Rigidbody2D rb2 = GetComponent<Rigidbody2D>();
        if(rb2 == null)
        {
            Debug.LogError("Rigidbody missing");
            return;
        }

        rb2.velocity = velocity;
    }
}
