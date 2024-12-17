using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private Rigidbody playerRb;
    private CharacterController characterController;
    public bool isMoving = false;
    public bool isRunning = false;
    public float movespeed = 6f;
    public bool isHiding;
    private bool isDead;

    //Stamina
    public Image StaminaBar;
    public float Stamina, MaxStamina;
    public float SprintCost;
    public float rechargeRate;
    private Coroutine recharge;

    public GameObject rockPrefab;

     public float rockSpeed;
   

    public GameManagerScript gameManager;


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

        characterController.Move(move * Time.deltaTime * movespeed);

        if (Input.anyKeyDown)
            isMoving = true;


        if (Input.GetKeyDown(KeyCode.LeftShift) & isMoving == true)
        {
            characterController.Move(move * Time.deltaTime * movespeed * 2);
            isRunning = true;
            Debug.Log("Sprinting");
        }
        if (isRunning == true)
        {
            movespeed = 12.0f;
            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) & isMoving == true)
        {
            isRunning = false;
        }
        if (isRunning == false)
        {
            movespeed = 10.0f;
        }
        if(Stamina == 0)
        {
            movespeed = 6.0f;
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
            
            /*if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(rockPrefab, transform.position + transform.forward, transform.rotation);
                transform.position += transform.forward * rockSpeed * Time.deltaTime;
            }*/

            Ray rayfromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, transform.position);
            groundPlane.Raycast(rayfromCamera, out float distanceFromCamera);
            Vector3 cursorPosition = rayfromCamera.GetPoint(distanceFromCamera);
            
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
