using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public float rotationSpeed, movementSpeed, distanceOfPlayer, fov;
    private float distance;

    public GameObject player;


    
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= fov)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.position - player.transform.position), rotationSpeed * Time.deltaTime);

            if (distance >= distanceOfPlayer)
            {
                transform.position += -transform.forward * movementSpeed * Time.deltaTime;
            }
        }
    }
}
