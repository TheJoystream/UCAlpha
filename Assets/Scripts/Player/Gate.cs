using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    public int keyRequirement;
    public int keyAmount;

    public GameObject gate;

    public playerInventory inventory;
    private bool playerHasKey;

    // Start is called before the first frame update
    void Start()
    {
        playerInventory inventory = GetComponent<playerInventory>();
    }

    


    // Update is called once per frame
    void Update()
    {
        //If keys collected are less than zero, display message "You need the key"
        playerInventory inventory = GetComponent<playerInventory>();
        if (inventory.keysAmount == 0)
        {
            Debug.Log("You need the key!");

            gate.GetComponent<BoxCollider>().enabled = true;
        }
        if (inventory.keysAmount >= 0)
        {
            Debug.Log("You escaped!");
            gate.GetComponent<BoxCollider>().enabled = false;
        }
    }

   /* public void OnTriggerEnter(Collider other)
    {
        playerInventory inventory = other.GetComponent<playerInventory>();
         if (inventory.keysAmount == 0)
        {
            Debug.Log("You need the key!");
            
            gate.GetComponent<BoxCollider>().enabled = true;
        }
               if (inventory.keysAmount >= 0)
        {
            Debug.Log("You escaped!");
            gate.GetComponent<BoxCollider>().enabled = false;
        }
    }*/
}
