using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public GameObject Bullet;
    public float Force = 1200f;

   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject BulletHolder;
            BulletHolder = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
            
            BulletHolder.transform.Rotate(Vector3.left * 90); // depends on the rotation of the weaponhold

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = BulletHolder.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.forward * Force);

            Destroy(BulletHolder, 2.0f); //instead of destroying gameobjects its better to do object pooling 


        }
    }
}
