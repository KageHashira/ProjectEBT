using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpact : MonoBehaviour
{
    public float damage = 25f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            PlayerHealth.health -= damage;

        }

        Destroy(gameObject);
    }
}
