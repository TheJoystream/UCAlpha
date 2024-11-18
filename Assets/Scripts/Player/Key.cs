using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour

{
    

    public GameObject gate;
    private Rigidbody player;


    private void Start()
    {
        
    }
    private void Update()
    {
        
    }





    private void OnTriggerEnter(Collider other)
    {
        
        playerInventory playerInventory = other.GetComponent<playerInventory>();

         if (playerInventory != null)
         {
            
            playerInventory.KeyCollected();
             gameObject.SetActive(false);
             Destroy(gameObject);
            gate.GetComponent<BoxCollider>().enabled = false;
            
            
         }
         
        if (other.gameObject.CompareTag("endkey"))
            {
            gate.SetActive(false);
        }

    }

    
}
