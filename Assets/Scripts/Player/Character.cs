using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody playerRb;
    private CharacterController characterController;
    public bool isMoving = false;
    public float speed = 20f;
    public bool isHiding;

    //Audio
    private AudioSource playerAudio;
    public AudioClip keyCollect;
    public AudioClip rockCollect;

  

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move * Time.deltaTime * speed);

        if(Input.anyKeyDown)
        {
            isMoving = true;
        }
     

        if (Input.GetKey(KeyCode.LeftShift) & isMoving == true)
        {
            characterController.Move(move * Time.deltaTime * speed * 2);
        }
        
        Hiding();
    }

    public void OnTriggerEnter(Collider other)
    {
        
        //GameObject.FindGameObjectsWithTag("Obstruction");

    }

    public void Hiding()
    {
        
    }

    private void KeyPickup()
    {
        
    }
}
