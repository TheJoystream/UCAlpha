using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    GameObject player;

    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;


    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer = false;
    public Transform target;

    public NavMeshAgent enemy;
    public Transform playerpos;
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());

    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    void FieldOfViewCheck()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;

            }
            if (canSeePlayer == true)
                {
                Chase();
            }
        }
    }

    public void Chase()
    {
        enemy.SetDestination(playerpos.position);
        //if (canSeePlayer == true)
       // {
            //transform.position = Vector3.MoveTowards(transform.position, target.position, 5f).normalized; transform.forward = target.forward;
       // }

        //if (canSeePlayer == false)
        //{
            //FieldOfViewCheck();
       // }
    }

    private Vector3 GetPosition()
    {
        return player.transform.position;
    }
}
