using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPickup : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip keypickup;
    private GameObject targetGameObject;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            audioSource.PlayOneShot(keypickup);
        }
       
    }

    

}
