using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("You escaped!");
    }
}
