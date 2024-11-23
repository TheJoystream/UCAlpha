using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
  
{
    public float speed = 20f;
    public float horizontalInput;
    public float verticalInput;

    public bool isMoving = false;

    public bool isHidden = false;

    // Start is called before the first frame update
    void Start()
    {
        isHidden = GetComponent<MeshRenderer>().enabled;
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
       
        if(Input.anyKeyDown)
                {
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.LeftShift) & isMoving == true) {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

    }

    /*public void Hidden()
    {
        OnCollisionEnter
    }*/

    private void OnCollisionEnter(Collision other)
    {
        GameObject.FindGameObjectsWithTag("Obstruction");
        
        {
            isHidden = GetComponent<MeshRenderer>().enabled == false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject.FindGameObjectsWithTag("Obstruction");

        {
            isHidden = GetComponent<MeshRenderer>().enabled == true;
        }
    }

}
