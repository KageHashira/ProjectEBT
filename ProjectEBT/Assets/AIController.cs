using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AIController : MonoBehaviour
{

    public float patrolSpeed;
    public float followSpeed;
    public float range;

    private GameObject player;
    private List<Vector3> patrolPoints = new List<Vector3>();
    private int currentPatrolPoint = 0;
    private bool isFollowing = false;

    void Start()
    {
        player = GameObject.Find("Player");
        patrolPoints.Add(new Vector3(0, 0, 0)); // add patrol points here
        patrolPoints.Add(new Vector3(10, 0, 0));
        patrolPoints.Add(new Vector3(10, 0, 10));
        patrolPoints.Add(new Vector3(0, 0, 10));
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer > range)
        {
            isFollowing = false;
            Patrol();
        }
        else
        {
            isFollowing = true;
            FollowPlayer();
        }
    }

    void Patrol()
    {
        Vector3 target = patrolPoints[currentPatrolPoint];
        transform.position = Vector3.MoveTowards(transform.position, target, patrolSpeed * Time.deltaTime);
        transform.LookAt(target);

        if (transform.position == target)
        {
            currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Count;
        }
    }

    void FollowPlayer()
    {
        Vector3 target = player.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, target, followSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}

