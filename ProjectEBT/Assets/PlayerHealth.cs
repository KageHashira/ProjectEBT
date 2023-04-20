using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static float health = 100f;
    public GameObject deadPlayer;

    // Update is called once per frame
    void Update()
    {
        if(health >= 100f)
        {
            health = 100f;

        }
        else if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deadPlayer, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
