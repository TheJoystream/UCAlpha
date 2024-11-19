using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{

    GameObject player;
    NavMeshAgent agent;

    [SerializeField] LayerMask targetLayer, groundLayer, obstructionLayer;

    //Patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    //State change
    [SerializeField] float sightRange;
    bool playerInSight;
    [SerializeField] private Transform playerpos;
    public Transform[] waypoints;
    public int currentWayPointIndex;
    
    
    


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        // Patrol();
        UpdateDestination();
        
    }

    // Update is called once per frame
    void Update()
    {
        /*playerInSight = Physics.CheckSphere(transform.position, sightRange, targetLayer);

        if (playerInSight)
        {
            Chase();
        }*/

        if (Vector3.Distance(transform.position, destPoint) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
            //Patrol();
        }
        
    }

   /* void Chase()
    {
        agent.SetDestination(player.transform.position);
       
        if(playerInSight == true)
        {
            Vector3 direction = player.transform.position;
        }
    }*/
   /* void Patrol()
    {
        if (!walkpointSet)
        { SearchForDest(); }

        if (walkpointSet)
        {
            agent.SetDestination(destPoint);
        }

        if (Vector3.Distance(transform.position, destPoint) < range)
        {
            walkpointSet = false;
            destPoint = waypoints[currentWayPointIndex].position;
            agent.SetDestination(destPoint);
        }
    }*/

    void IterateWaypointIndex()
    {
        currentWayPointIndex++;
        if(currentWayPointIndex== waypoints.Length)
        {
            currentWayPointIndex = 0;
        }
    }

    void UpdateDestination()
    {
        destPoint = waypoints[currentWayPointIndex].position;
        agent.SetDestination(destPoint);
    }
    
/*void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }*/


    
}
