using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   

        public float range = 10f; // The maximum range the AI can follow the player
        public float speed = 5f; // The speed at which the AI moves towards the player

        private Transform player; // Reference to the player's transform

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player object in the scene
        }

        void Update()
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= range)
            {
                Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }


