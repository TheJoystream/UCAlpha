using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class EnemyFollow : MonoBehaviour
{
    //Chase AI
    NavMeshAgent agent;
    GameObject player;
    public Transform Player;
    public float radius;
    public bool playerInSight = true;
        

    //Waypoints
    Vector3 target;
    public Transform[] patrolPoints;
    public int targetPoint;
    public int targetPointIndex;
    public float speed;

    //Patrol

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        targetPoint = 0;
       // Patrol();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == patrolPoints[targetPointIndex].position)
        {
            increaseTargetInt();

}

        if (playerInSight == true)
        {
            Chase();
        }
        if (playerInSight == false)
        {
       //     Patrol();
        }
        
    
    }
    
    void increaseTargetInt()
{
    targetPoint++;
    if (targetPoint >= patrolPoints.Length)
    { targetPoint = 0; }
}

    public void Chase()
    {

        agent.SetDestination(Player.position);
    }
    
    
    /* public void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        transform.LookAt(patrolPoints[targetPoint].position);
    }

    void UpdateDestination()
    {
        target = patrolPoints[targetPoint].position;
        agent.SetDestination(target);
    }

    void IteratePatrolPointsIndex()
    {
        targetPointIndex++;
        if(targetPointIndex < patrolPoints.Length)
        {
            targetPointIndex = 0;
        }
    }*/
}
