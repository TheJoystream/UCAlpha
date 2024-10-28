using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public float radius;
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
   

    

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);
    
    
       if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();

}
transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        
transform.LookAt(patrolPoints[targetPoint].position);

        
    }
    

    void increaseTargetInt()
{
    targetPoint++;
    if (targetPoint >= patrolPoints.Length)
    { targetPoint = 0; }
}
    
}
