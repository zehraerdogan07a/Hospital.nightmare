using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    [SerializeField]
    int hurtAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth ehealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (ehealth == null)
        {
            return;
        }

        ehealth.Hurt(hurtAmount);
        Destroy(gameObject);
    }
}
