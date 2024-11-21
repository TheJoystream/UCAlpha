using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private Rigidbody playerRb;
    private CharacterController characterController;
    public bool isMoving;
    public float speed = 6f;
    private float sprintSpeed = 12f;
    private float staminaDecreaseRate = 2f;
    private float staminaIncreaseRate = 2f;
    public bool isHiding;
    public float stamina = 100f;
    public float totalStamina = 100f;
    public bool staminaDepleted;
    //private Slider uiManager;
    
    



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
       // slider = (Slider)GetComponent(typeof(Slider));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        characterController.Move(move * Time.deltaTime * speed);

        if (move.x == 0 && move.y == 0)
            isMoving = false;
        else
        isMoving = true;
     

       // if (Input.GetKey(KeyCode.LeftShift) & isMoving == true)
        {//
           characterController.Move(move * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.LeftShift) && staminaDepleted == false && isMoving == true)
        {
            if (totalStamina > 0f)
            {
                speed = sprintSpeed;
                totalStamina -= staminaDecreaseRate * Time.deltaTime;
            }
            else
            {
                totalStamina = 0f;
                staminaDepleted = true;
            }
        }
        else
        {
            speed = 6f;
            if (stamina < totalStamina)
            {
                totalStamina += staminaIncreaseRate * Time.deltaTime;
            }
            else
            {
                totalStamina = 0;
                staminaDepleted = true;
            }
        }
        //_uiManager.UpdateStamina(totalStamina, staminaDepleted);
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
