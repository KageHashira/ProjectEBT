using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIfollow : MonoBehaviour
{
    //ai sight 
    public bool playerIsInLOS = false;
    public float fieldOfViewAngle = 160f;
    public float losRadius = 45f;


    // ai memory 
    public float memoryStartTime = 10f;
    private float increasingMemoryTime;

        


    //patrolling randomly between waypoints 
    public Transform[] moveSpots;
    public int randomSpot;

    //wait time at waypoint for patrolling 
    private float waitTime;
    public float startWaitTime = 1f;

    NavMeshAgent nav;

    //AI strafe 
    public float distToPlayer = 5.0f; // straferadius

   


    //when to chase player 
    public float chaseRadius = 20f;

    public float facePlayerFactor = 20f;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;


    }

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);

    }

    void Update()
    {
        //float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        /*if (distance > chaseRadius)
        {
            Patrol();

        }
        else if (distance <= chaseRadius)
        {
            ChasePlayer();

            FacePlayer();
        }*/

        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);
        if(distance <= losRadius)
        {
            CheckLOS();
        }
        
        if(nav.isActiveAndEnabled)
        {
            if(playerIsInLOS == false)
            {
                Patrol();

            }
            else if(playerIsInLOS == true)
            {
                

                FacePlayer();
                ChasePlayer();

            }
        }
    }

    void CheckLOS()
    {
        Vector3 direction = PlayerMovement.playerPos - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < fieldOfViewAngle*0.5f)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            {
                if(hit.collider.tag == "Player")
                {
                    playerIsInLOS = true;

                    
                }
                else
                {
                    playerIsInLOS = false;

                }
            }

        }

        

        
        
    }

    void Patrol()
    {

        nav.SetDestination(moveSpots[randomSpot].position);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);

                waitTime = startWaitTime;

            }
            else { waitTime -= Time.deltaTime; }

        }
    }

    void ChasePlayer()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        if (distance <= chaseRadius && distance > distToPlayer)
        {
            nav.SetDestination(PlayerMovement.playerPos);

        }
        

    }

    void FacePlayer()
    {
        Vector3 direction = (PlayerMovement.playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

    }
}
