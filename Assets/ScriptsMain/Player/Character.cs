using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //Character attributes
    private Rigidbody playerRb;
    private CharacterController characterController;
    public bool isMoving = false;
    public bool isRunning = false;
    public float movespeed = 10f;
    public bool isHiding;
    private bool isDead;

    //Stamina
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float SprintCost;
    public float rechargeRate;
    private Coroutine recharge;
   

    public GameManagerScript gameManager;


    //Audio
    private AudioSource playerAudio;
    public AudioClip keyCollect;
    public AudioClip rockCollect;

    public Animator anim;



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

        characterController.Move(move * movespeed * Time.deltaTime);

        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        if (Input.anyKeyDown)
            isMoving = true;
        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);


        if (Input.GetKeyDown(KeyCode.LeftShift) & isMoving == true)
        {
            characterController.Move(move * movespeed *2 *Time.deltaTime);
            isRunning = true;
            //Debug.Log("Sprinting");
            anim.SetBool("isRunning", true);
        }
        else
        {
            //this.anim.SetBool("isRunning", false);
        }
        if (isRunning == true)
        {
            movespeed = 20.0f;
            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) & isMoving == true)
        {
            isRunning = false;
            anim.SetBool("isRunning", false);
        }
        if (isRunning == false)
        {
            movespeed = 10.0f;
        }
        if(Stamina == 0)
        {
            movespeed = 10.0f;
            isRunning = false;
        }
        {
            if (isRunning == true)
            {

                Stamina -= SprintCost * Time.deltaTime;
                if (Stamina < 0) Stamina = 0;
                StaminaBar.fillAmount = Stamina / MaxStamina;

                if (recharge != null) StopCoroutine(recharge);
                recharge = StartCoroutine(RechargeStamina());
            }
        }
    }

    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(2f);

        while (Stamina < MaxStamina)
        {
            Stamina += rechargeRate / 10f;
            if (Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }       
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("Enemy") && !isDead)
        {
            isDead = true;
            gameManager.GameOver();
            Debug.Log("You got caught!");
            Destroy(this.gameObject);
        }
    }
}
