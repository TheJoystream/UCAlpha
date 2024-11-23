using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Ends the game when player reaches certain point
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        other.gameObject.SetActive(false);
        Debug.Log("You got caught!");
    }
}