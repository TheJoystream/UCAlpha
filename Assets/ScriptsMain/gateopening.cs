using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateopening : MonoBehaviour
{
    // Start is called before the first frame update

    Animator gateAnim;
    public playerInventory inventory;
    
    void Start()
    {
        
        gateAnim = this.transform.parent.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && inventory.hasKey == true)
        { gateAnim.SetBool("isOpening", true); }
    }
}
