using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPickup : MonoBehaviour
{

    private AudioSource audioSource;
    private GameObject targetGameObject;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        audioSource.Play();
    }

}
