using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingAI : MonoBehaviour
{
    public float speed = 5f;            // AI speed
    public float rotationSpeed = 2f;    // AI rotation speed
    public float lineOfSight = 10f;     // AI line of sight
    public float stoppingDistance = 2f; // Distance at which the AI will stop following the player
    public Transform[] waypoints;       // Array of waypoints for the AI to patrol

    private Transform player;           // Player transform
    private int currentWaypointIndex = 0;// Index of the current waypoint
    private bool playerInSight = false; // Whether the player is in the AI's line of sight

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // If the player is in the AI's line of sight, follow it
        if (playerInSight)
        {
            // Rotate towards the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move towards the player
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance > stoppingDistance)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        else // Otherwise, patrol between waypoints
        {
            // Move towards the current waypoint
            float distance = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
            if (distance < stoppingDistance)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
                direction.y = 0;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the AI's line of sight, set playerInSight to true
        if (other.CompareTag("Player"))
        {
            playerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player exits the AI's line of sight, set playerInSight to false
        if (other.CompareTag("Player"))
        {
            playerInSight = false;
        }
    }
}


