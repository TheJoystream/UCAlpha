using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public bool locked;
    public playerInventory inventory;
    public GameObject gateCollider;
    // Start is called before the first frame update
    void Start()
    {
        locked = true;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && inventory.hasKey == true)
        {
            locked = false;
            gameObject.SetActive(false);


            
        }
        
        
        
    }
}
