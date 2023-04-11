using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PatrolAndFollow : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 3f;
    public float detectionDistance = 5f;

    private int currentWaypoint = 0;
    private bool isFollowing = false;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isFollowing)
        {
            Patrol();
        }
        else
        {
            Follow();
        }
    }

    void Patrol()
    {
        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);

        // Check if the AI has reached the current waypoint
        if (transform.position == waypoints[currentWaypoint].position)
        {
            // Move to the next waypoint
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        // Check if the player is close enough to follow
        if (Vector3.Distance(transform.position, playerTransform.position) < detectionDistance)
        {
            isFollowing = true;
        }
    }

    void Follow()
    {
        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        // Check if the player is too far away to follow
        if (Vector3.Distance(transform.position, playerTransform.position) > detectionDistance)
        {
            isFollowing = false;
        }
    }
}

