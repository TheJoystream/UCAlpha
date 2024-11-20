using UnityEngine;
using UnityEngine.AI;

public class LineOfSight : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        NavMeshHit hit;
        if (!agent.Raycast(target.position, out hit))
        {
            // Target is "visible" from our position.
        }
    }
}