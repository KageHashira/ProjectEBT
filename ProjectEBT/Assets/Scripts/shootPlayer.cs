using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPlayer : MonoBehaviour
{
    public GameObject Bullet;

    // shot timing 
    private float timerShots;
    public float timeBtwShots;

    public float fireRadius = 25f;
    public float Force = 1200f;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);
        
        if(distance <= fireRadius)
        {
            AI_FireBullet();
        }
    }

    void AI_FireBullet()
    {
        RaycastHit hitPlayer;
        Ray playerPos = new Ray(transform.position, transform.forward);

        if(Physics.SphereCast(playerPos, 0.25f, out hitPlayer, fireRadius))
        {
            if(timerShots <= 0 && hitPlayer.transform.tag == "Player")
            {
                GameObject BulletHolder;
                BulletHolder = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;

                BulletHolder.transform.Rotate(Vector3.left * 90);

                Rigidbody Temp_RigidBody;
                Temp_RigidBody = BulletHolder.GetComponent<Rigidbody>();

                Temp_RigidBody.AddForce(transform.forward * Force);

                Destroy(BulletHolder, 2.0f);

                timerShots = timeBtwShots;


            }
            else
            {
                timerShots -= Time.deltaTime;

            }
        }
    }
}
