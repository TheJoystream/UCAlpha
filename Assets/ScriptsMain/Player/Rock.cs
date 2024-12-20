using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float speed;




    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        playerInventory playerInventory = other.GetComponent<playerInventory>();

        if (playerInventory != null)
        {
            playerInventory.RockCollected();
            gameObject.SetActive(false);
        }
    }
}
