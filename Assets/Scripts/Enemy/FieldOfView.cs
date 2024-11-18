using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    GameObject player;

    public float radius;
    [Range(0, 360)]
    public float angle;

    public GameObject playerRef;


    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    private Transform target;

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
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
        }

    }

    public void Chase()
    {
        if (canSeePlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 5f).normalized; transform.forward = target.forward;
        }
    }

    private Vector3 GetPosition()
    {
        return player.transform.position;
    }
}
