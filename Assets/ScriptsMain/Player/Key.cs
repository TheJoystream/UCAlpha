using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour

{
    public AudioSource pickup;
    public AudioClip pickupkey;

    public GameObject gate;
    private Rigidbody player;


    private void Start()
    {
        pickup = GetComponent<AudioSource>();
        
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
             
            gate.GetComponent<BoxCollider>().enabled = false;
            
            
         }

        if (other.gameObject.CompareTag("endkey"))
            {
            gate.SetActive(false);
        }

        

    }

    
}
