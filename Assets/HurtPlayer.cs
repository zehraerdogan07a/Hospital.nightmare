using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    [SerializeField]
    int hurtAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth phealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (phealth == null)
        {
            return;
        }

        phealth.Hurt(hurtAmount);
        Destroy(gameObject);
    }
}
