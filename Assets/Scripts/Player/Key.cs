using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        playerInventory playerInventory = other.GetComponent<playerInventory>();

        if (playerInventory.KeyCollected != null)
        {
            playerInventory.KeyCollected();
            gameObject.SetActive(false);
        }
    }
}
