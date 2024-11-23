using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    GameObject player;

    //Detection
    public float radius;
    [Range(0, 360)]
    public float angle;
    public GameObject playerRef;

    //LayerMasks
    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer = false;
    public Transform target;

    public NavMeshAgent enemy;
    public Transform playerpos;

    //Audio
    public AudioSource spottedAudio;
    public AudioClip playerSpotted;
    // Start is called before the first frame update
    void Start()
    {
        //Sets reference to Player
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        spottedAudio = GetComponent<AudioSource>();

    }

    //
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
        //Range check for player
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

    
    //Enemy chases player
    public void Chase()
    {
        enemy.SetDestination(playerpos.position);
       // spottedAudio.PlayOneShot(playerSpotted);
        
    }

    /*private Vector3 GetPosition()
    {
        return player.transform.position;
    }*/
   

}
