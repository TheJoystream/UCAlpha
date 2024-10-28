using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    public bool locked;
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
        if(other.gameObject.CompareTag("endkey"))
        {
            locked = false;

            
        }
        
        
        
    }
}
